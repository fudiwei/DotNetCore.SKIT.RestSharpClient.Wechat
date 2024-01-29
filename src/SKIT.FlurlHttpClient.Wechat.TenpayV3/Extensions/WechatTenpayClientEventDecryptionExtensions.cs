using System;
using System.Text;

namespace SKIT.FlurlHttpClient.Wechat.TenpayV3
{
    public static class WechatTenpayClientEventDecryptionExtensions
    {
        /// <summary>
        /// <para>反序列化得到 <see cref="WechatTenpayEvent"/> 对象。</para>
        /// </summary>
        /// <param name="client"></param>
        /// <param name="webhookJson"></param>
        /// <returns></returns>
        public static WechatTenpayEvent DeserializeEvent(this WechatTenpayClient client, string webhookJson)
        {
            if (client is null) throw new ArgumentNullException(nameof(client));
            if (string.IsNullOrEmpty(webhookJson)) throw new ArgumentNullException(webhookJson);

            return client.JsonSerializer.Deserialize<WechatTenpayEvent>(webhookJson);
        }

        /// <summary>
        /// 返回序列化并解密事件数据中被加密的通知数据。
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="client"></param>
        /// <param name="webhookEvent"></param>
        /// <returns></returns>
        public static T DecryptEventResource<T>(this WechatTenpayClient client, WechatTenpayEvent webhookEvent)
            where T : WechatTenpayEvent.Types.IDecryptedResource, new()
        {
            if (client is null) throw new ArgumentNullException(nameof(client));
            if (webhookEvent is null) throw new ArgumentNullException(nameof(webhookEvent));

            return DecryptEventResource<T>(client, webhookEvent.Resource);
        }

        /// <summary>
        /// 返回序列化并解密事件数据中被加密的通知数据。
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="client"></param>
        /// <param name="webhookEventResource"></param>
        /// <returns></returns>
        public static T DecryptEventResource<T>(this WechatTenpayClient client, WechatTenpayEvent.Types.Resource webhookEventResource)
            where T : WechatTenpayEvent.Types.IDecryptedResource, new()
        {
            if (client is null) throw new ArgumentNullException(nameof(client));
            if (webhookEventResource is null) throw new ArgumentNullException(nameof(webhookEventResource));

            string plainJson;
            switch (webhookEventResource.Algorithm)
            {
                case Constants.EncryptionAlgorithms.AEAD_AES_256_GCM:
                    {
                        try
                        {
                            plainJson = Utilities.AESUtility.DecryptWithGCM(
                                key: client.Credentials.MerchantV3Secret,
                                nonce: webhookEventResource.Nonce,
                                aad: webhookEventResource.AssociatedData,
                                cipherText: webhookEventResource.CipherText
                            );
                        }
                        catch (Exception ex)
                        {
                            throw new WechatTenpayException("Failed to decrypt event resource data. Please see the inner exception for more details.", ex);
                        }
                    }
                    break;

                case Constants.EncryptionAlgorithms.AEAD_SM4_128_GCM:
                    {
                        try
                        {
                            // REF: https://pay.weixin.qq.com/docs/merchant/development/shangmi/guide.html
                            // 由于 SM4 密钥长度的限制，密钥由 APIv3 密钥通过国密 SM3 Hash 计算生成。SM4 密钥取其摘要（256bit）的前 128bit。
                            byte[] secretBytes = Utilities.SM3Utility.Hash(Encoding.UTF8.GetBytes(client.Credentials.MerchantV3Secret));
                            byte[] keyBytes = new byte[16];
                            Array.Copy(secretBytes, keyBytes, keyBytes.Length);

                            byte[] plainBytes = Utilities.SM4Utility.DecryptWithGCM(
                                keyBytes: keyBytes,
                                nonceBytes: Encoding.UTF8.GetBytes(webhookEventResource.Nonce),
                                aadBytes: webhookEventResource.AssociatedData is null ? null : Encoding.UTF8.GetBytes(webhookEventResource.AssociatedData),
                                cipherBytes: Convert.FromBase64String(webhookEventResource.CipherText)
                            );
                            plainJson = Encoding.UTF8.GetString(plainBytes);
                        }
                        catch (Exception ex)
                        {
                            throw new WechatTenpayException("Failed to decrypt event resource data. Please see the inner exception for more details.", ex);
                        }
                    }
                    break;

                default:
                    {
                        throw new WechatTenpayException($"Failed to decrypt event resource data. Unsupported encryption algorithm: \"{webhookEventResource.Algorithm}\".");
                    }
            }

            return client.JsonSerializer.Deserialize<T>(plainJson);
        }
    }
}
