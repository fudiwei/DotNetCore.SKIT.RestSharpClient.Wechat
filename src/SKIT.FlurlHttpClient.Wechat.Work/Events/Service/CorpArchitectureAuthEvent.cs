﻿namespace SKIT.FlurlHttpClient.Wechat.Work.Events
{
    /// <summary>
    /// <para>表示 INFO.corp_arch_auth 事件的数据。</para>
    /// <para>REF: https://developer.work.weixin.qq.com/document/path/97378 </para>
    /// </summary>
    public class CorpArchitectureAuthEvent : WechatWorkEvent, WechatWorkEvent.Serialization.IXmlSerializable
    {
        /// <summary>
        /// 获取或设置第三方应用的 SuiteId。
        /// </summary>
        [System.Xml.Serialization.XmlElement("SuiteId")]
        public string SuiteId { get; set; } = default!;

        /// <summary>
        /// 获取或设置授权方的 CorpId。
        /// </summary>
        [System.Xml.Serialization.XmlElement("AuthCorpId")]
        public string AuthorizerCorpId { get; set; } = default!;
    }
}
