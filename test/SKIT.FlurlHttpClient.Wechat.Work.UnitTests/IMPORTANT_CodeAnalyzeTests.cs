using System;
using System.IO;
using System.Reflection;
using SKIT.FlurlHttpClient.Tools.CodeAnalyzer;
using Xunit;

namespace SKIT.FlurlHttpClient.Wechat.Work.UnitTests
{
    public class CodeAnalyzeTests
    {
        [Fact(DisplayName = "代码质量分析")]
        public void CodeAnalyze()
        {
            Assert.Null(Record.Exception(() =>
            {
                var options = new TypeDeclarationAnalyzerOptions()
                {
                    SdkAssembly = Assembly.GetAssembly(typeof(WechatWorkClient))!,
                    SdkRequestModelDeclarationNamespace = "SKIT.FlurlHttpClient.Wechat.Work.Models",
                    SdkResponseModelDeclarationNamespace = "SKIT.FlurlHttpClient.Wechat.Work.Models",
                    SdkExecutingExtensionDeclarationNamespace = "SKIT.FlurlHttpClient.Wechat.Work",
                    SdkWebhookEventDeclarationNamespace = "SKIT.FlurlHttpClient.Wechat.Work.Events",
                    ThrowOnNotFoundRequestModelTypes = true,
                    ThrowOnNotFoundResponseModelTypes = true,
                    ThrowOnNotFoundExecutingExtensionTypes = true,
                    ThrowOnNotFoundWebhookEventTypes = true
                };
                new TypeDeclarationAnalyzer(options).AssertNoIssues();
            }));

            Assert.Null(Record.Exception(() =>
            {
                string workdir = Environment.CurrentDirectory;
                string projdir = Path.Combine(workdir, "../../../../../");

                var options = new SourceFileAnalyzerOptions()
                {
                    SdkAssembly = Assembly.GetAssembly(typeof(WechatWorkClient))!,
                    SdkRequestModelDeclarationNamespace = "SKIT.FlurlHttpClient.Wechat.Work.Models",
                    SdkResponseModelDeclarationNamespace = "SKIT.FlurlHttpClient.Wechat.Work.Models",
                    SdkWebhookEventDeclarationNamespace = "SKIT.FlurlHttpClient.Wechat.Work.Events",
                    ProjectSourceRootDirectory = Path.Combine(projdir, "./src/SKIT.FlurlHttpClient.Wechat.Work/"),
                    ProjectTestRootDirectory = Path.Combine(projdir, "./test/SKIT.FlurlHttpClient.Wechat.Work.UnitTests/"),
                    ThrowOnNotFoundRequestModelClassCodeFiles = true,
                    ThrowOnNotFoundResponseModelClassCodeFiles = true,
                    ThrowOnNotFoundExecutingExtensionClassCodeFiles = true,
                    ThrowOnNotFoundWebhookEventClassCodeFiles = true,
                    ThrowOnNotFoundRequestModelSerializationSampleFiles = true,
                    ThrowOnNotFoundResponseModelSerializationSampleFiles = true,
                    ThrowOnNotFoundWebhookEventSerializationSampleFiles = true
                };
                new SourceFileAnalyzer(options).AssertNoIssues();
            }));
        }
    }
}
