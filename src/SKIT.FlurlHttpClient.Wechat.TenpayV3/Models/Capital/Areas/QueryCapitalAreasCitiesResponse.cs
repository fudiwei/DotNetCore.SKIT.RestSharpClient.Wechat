﻿namespace SKIT.FlurlHttpClient.Wechat.TenpayV3.Models
{
    /// <summary>
    /// <para>表示 [GET] /capital/capitallhh/areas/provinces/{province_code}/cities 接口的响应。</para>
    /// </summary>
    public class QueryCapitalAreasCitiesResponse : WechatTenpayResponse
    {
        public static class Types
        {
            public class City
            {
                /// <summary>
                /// 获取或设置城市名称。
                /// </summary>
                [Newtonsoft.Json.JsonProperty("city_name")]
                [System.Text.Json.Serialization.JsonPropertyName("city_name")]
                public string CityName { get; set; } = default!;

                /// <summary>
                /// 获取或设置城市编码。
                /// </summary>
                [Newtonsoft.Json.JsonProperty("city_code")]
                [System.Text.Json.Serialization.JsonPropertyName("city_code")]
                public int CityCode { get; set; }
            }
        }

        /// <summary>
        /// 获取或设置城市列表。
        /// </summary>
        [Newtonsoft.Json.JsonProperty("data")]
        [System.Text.Json.Serialization.JsonPropertyName("data")]
        public Types.City[] CityList { get; set; } = default!;

        /// <summary>
        /// 获取或设置数据总条数。
        /// </summary>
        [Newtonsoft.Json.JsonProperty("total_count")]
        [System.Text.Json.Serialization.JsonPropertyName("total_count")]
        public int TotalCount { get; set; }
    }
}
