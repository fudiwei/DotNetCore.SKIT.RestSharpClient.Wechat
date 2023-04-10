namespace SKIT.FlurlHttpClient.Wechat.TenpayBusiness.Models
{
    /// <summary>
    /// <para>表示 [POST] /mse-pay/bill-downloads 接口的响应。</para>
    /// </summary>
    public class GetBillResponse : WechatTenpayBusinessResponse
    {
        /// <summary>
        /// 获取或设置哈希类型。
        /// </summary>
        [Newtonsoft.Json.JsonProperty("hash_type")]
        [System.Text.Json.Serialization.JsonPropertyName("hash_type")]
        public string HashType { get; set; } = default!;

        /// <summary>
        /// 获取或设置哈希值。
        /// </summary>
        [Newtonsoft.Json.JsonProperty("hash_value")]
        [System.Text.Json.Serialization.JsonPropertyName("hash_value")]
        public string HashValue { get; set; } = default!;

        /// <summary>
        /// 获取或设置账单下载地址。
        /// </summary>
        [Newtonsoft.Json.JsonProperty("download_url")]
        [System.Text.Json.Serialization.JsonPropertyName("download_url")]
        public string DownloadUrl { get; set; } = default!;
    }
}
