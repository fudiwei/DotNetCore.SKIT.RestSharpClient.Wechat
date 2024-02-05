using Xunit;

namespace SKIT.FlurlHttpClient.Wechat.TenpayBusiness.UnitTests
{
    using SKIT.FlurlHttpClient.Primitives;

    public class TestCase_ToolsSM4UtilityTests
    {
        [Fact(DisplayName = "测试用例：SM4 加密")]
        public void TestSM4Encrypt()
        {
            string key = "MDAwMDAwMDAwMDAwMDAwMA==";
            string iv = "OGE2YzRkZGQ4YTZjNGRkZA==";
            string plainText = "Awesome SKIT.FlurlHttpClient.Wechat.TenpayBusiness!";

            string actualCipher = Utilities.SM4Utility.EncryptWithCBC(encodingKey: (EncodedString)key, encodingIV: (EncodedString)iv, plainData: plainText)!;
            string expectedCipher = "Fm3z4Ipjuaj4oQLfxpTrvoZm5JdbjvjrJo3PRhvSsOppk8/PN+izH3Wo9Rz6V85mpq6X1cGul8U7jjaAl1PWpg==";

            Assert.Equal(expectedCipher, actualCipher);
        }

        [Fact(DisplayName = "测试用例：SM4 解密")]
        public void TestSM4Decrypt()
        {
            string key = "MDAwMDAwMDAwMDAwMDAwMA==";
            string iv = "OGE2YzRkZGQ4YTZjNGRkZA==";
            string cipherText = "Fm3z4Ipjuaj4oQLfxpTrvoZm5JdbjvjrJo3PRhvSsOppk8/PN+izH3Wo9Rz6V85mpq6X1cGul8U7jjaAl1PWpg==";

            string actualPlain = Utilities.SM4Utility.DecryptWithCBC(encodingKey: (EncodedString)key, encodingIV: (EncodedString)iv, encodingCipher: (EncodedString)cipherText)!;
            string expectedPlain = "Awesome SKIT.FlurlHttpClient.Wechat.TenpayBusiness!";

            Assert.Equal(expectedPlain, actualPlain);
        }
    }
}
