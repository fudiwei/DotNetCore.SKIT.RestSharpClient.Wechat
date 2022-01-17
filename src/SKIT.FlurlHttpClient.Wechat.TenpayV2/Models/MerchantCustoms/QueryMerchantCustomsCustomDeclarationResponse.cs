﻿using System;
using System.Reflection;

namespace SKIT.FlurlHttpClient.Wechat.TenpayV2.Models
{
    /// <summary>
    /// <para>表示 [POST] /cgi-bin/mch/customs/customdeclarequery 接口的响应。</para>
    /// </summary>
    [Newtonsoft.Json.JsonConverter(typeof(Converters.ResponseClassNewtonsoftJsonConverter))]
    [System.Text.Json.Serialization.JsonConverter(typeof(Converters.ResponseClassSystemTextJsonConverter))]
    public class QueryMerchantCustomsCustomDeclarationResponse : WechatTenpaySignableResponse
    {
        public static class Types
        {
            public class Record
            {
                /// <summary>
                /// 获取或设置状态码。
                /// </summary>
                [Newtonsoft.Json.JsonProperty("state_$n")]
                [System.Text.Json.Serialization.JsonPropertyName("state_$n")]
                public string State { get; set; } = default!;

                /// <summary>
                /// 获取或设置商户子订单号。
                /// </summary>
                [Newtonsoft.Json.JsonProperty("sub_order_no_$n")]
                [System.Text.Json.Serialization.JsonPropertyName("sub_order_no_$n")]
                public string? SubOrderNumber { get; set; }

                /// <summary>
                /// 获取或设置微信子订单号。
                /// </summary>
                [Newtonsoft.Json.JsonProperty("sub_order_id_$n")]
                [System.Text.Json.Serialization.JsonPropertyName("sub_order_id_$n")]
                public string? SubOrderIdList { get; set; }

                /// <summary>
                /// 获取或设置海关。
                /// </summary>
                [Newtonsoft.Json.JsonProperty("customs_$n")]
                [System.Text.Json.Serialization.JsonPropertyName("customs_$n")]
                public string CustomsList { get; set; } = default!;

                /// <summary>
                /// 获取或设置商户海关备案号。
                /// </summary>
                [Newtonsoft.Json.JsonProperty("mch_customs_no_$n")]
                [System.Text.Json.Serialization.JsonPropertyName("mch_customs_no_$n")]
                public string MerchantCustomsNumberList { get; set; } = default!;

                /// <summary>
                /// 获取或设置关税（单位：分）。
                /// </summary>
                [Newtonsoft.Json.JsonProperty("duty_$n")]
                [System.Text.Json.Serialization.JsonPropertyName("duty_$n")]
                public int? Duty { get; set; }

                /// <summary>
                /// 获取或设置币种。
                /// </summary>
                [Newtonsoft.Json.JsonProperty("fee_type_$n")]
                [System.Text.Json.Serialization.JsonPropertyName("fee_type_$n")]
                public string? FeeType { get; set; }

                /// <summary>
                /// 获取或设置应付金额（单位：分）。
                /// </summary>
                [Newtonsoft.Json.JsonProperty("order_fee_$n")]
                [System.Text.Json.Serialization.JsonPropertyName("order_fee_$n")]
                public int? OrderFee { get; set; }

                /// <summary>
                /// 获取或设置物流费（单位：分）。
                /// </summary>
                [Newtonsoft.Json.JsonProperty("transport_fee_$n")]
                [System.Text.Json.Serialization.JsonPropertyName("transport_fee_$n")]
                public int? TransportFee { get; set; }

                /// <summary>
                /// 获取或设置商品价格（单位：分）。
                /// </summary>
                [Newtonsoft.Json.JsonProperty("product_fee_$n")]
                [System.Text.Json.Serialization.JsonPropertyName("product_fee_$n")]
                public int? ProductFee { get; set; }

                /// <summary>
                /// 获取或设置最后更新时间。
                /// </summary>
                [Newtonsoft.Json.JsonProperty("modify_time_$n")]
                [Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.PureDigitalTextDateTimeOffsetConverter))]
                [System.Text.Json.Serialization.JsonPropertyName("modify_time_$n")]
                [System.Text.Json.Serialization.JsonConverter(typeof(System.Text.Json.Converters.PureDigitalTextDateTimeOffsetConverter))]
                public DateTimeOffset ModifyTime { get; set; }

                /// <summary>
                /// 获取或设置订购人和支付人身份信息校验结果。
                /// </summary>
                [Newtonsoft.Json.JsonProperty("cert_check_result_$n")]
                [System.Text.Json.Serialization.JsonPropertyName("cert_check_result_$n")]
                public string? CertificateCheckResult { get; set; }

                /// <summary>
                /// 获取或设置申报结果说明。
                /// </summary>
                [Newtonsoft.Json.JsonProperty("explanation_$n")]
                [System.Text.Json.Serialization.JsonPropertyName("explanation_$n")]
                public string? Explanation { get; set; }
            }
        }

        internal static class Converters
        {
            internal class ResponseClassNewtonsoftJsonConverter : Newtonsoft.Json.JsonConverter<QueryMerchantCustomsCustomDeclarationResponse?>
            {
                public override bool CanRead
                {
                    get { return true; }
                }

                public override bool CanWrite
                {
                    get { return false; }
                }

                public override QueryMerchantCustomsCustomDeclarationResponse? ReadJson(Newtonsoft.Json.JsonReader reader, Type objectType, QueryMerchantCustomsCustomDeclarationResponse? existingValue, bool hasExistingValue, Newtonsoft.Json.JsonSerializer serializer)
                {
                    if (reader.TokenType == Newtonsoft.Json.JsonToken.Null)
                    {
                        return existingValue;
                    }
                    else if (reader.TokenType == Newtonsoft.Json.JsonToken.StartObject)
                    {
                        var jObject = serializer.Deserialize<Newtonsoft.Json.Linq.JObject>(reader);
                        return Utilities.ReflectionUtility.DeserializeFromJson<QueryMerchantCustomsCustomDeclarationResponse>(ref jObject, serializer);
                    }

                    throw new Newtonsoft.Json.JsonSerializationException();
                }

                public override void WriteJson(Newtonsoft.Json.JsonWriter writer, QueryMerchantCustomsCustomDeclarationResponse? value, Newtonsoft.Json.JsonSerializer serializer)
                {
                    throw new NotImplementedException();
                }
            }

            internal class ResponseClassSystemTextJsonConverter : System.Text.Json.Serialization.JsonConverter<QueryMerchantCustomsCustomDeclarationResponse?>
            {
                public override QueryMerchantCustomsCustomDeclarationResponse? Read(ref System.Text.Json.Utf8JsonReader reader, Type typeToConvert, System.Text.Json.JsonSerializerOptions options)
                {
                    if (reader.TokenType == System.Text.Json.JsonTokenType.Null)
                    {
                        return default;
                    }
                    else if (reader.TokenType == System.Text.Json.JsonTokenType.StartObject)
                    {
                        var jElement = System.Text.Json.JsonDocument.ParseValue(ref reader).RootElement.Clone();
                        return Utilities.ReflectionUtility.DeserializeFromJson<QueryMerchantCustomsCustomDeclarationResponse>(ref jElement);
                    }

                    throw new NotImplementedException();
                }

                public override void Write(System.Text.Json.Utf8JsonWriter writer, QueryMerchantCustomsCustomDeclarationResponse? value, System.Text.Json.JsonSerializerOptions options)
                {
                    throw new NotImplementedException();
                }
            }
        }
        
        /// <summary>
        /// 获取或设置微信支付订单号。
        /// </summary>
        [Newtonsoft.Json.JsonProperty("transaction_id")]
        [System.Text.Json.Serialization.JsonPropertyName("transaction_id")]
        public string TransactionId { get; set; } = default!;

        /// <summary>
        /// 获取或设置记录列表。
        /// </summary>
        [Newtonsoft.Json.JsonProperty("#$n")]
        [System.Text.Json.Serialization.JsonPropertyName("#$n")]
        public Types.Record[] RecordList { get; set; } = default!;

        /// <summary>
        /// 获取或设置记录总数。
        /// </summary>
        [Newtonsoft.Json.JsonProperty("count")]
        [System.Text.Json.Serialization.JsonPropertyName("count")]
        public int RecordCount { get; set; }

        /// <summary>
        /// 获取或设置验核机构。
        /// </summary>
        [Newtonsoft.Json.JsonProperty("verify_department")]
        [System.Text.Json.Serialization.JsonPropertyName("verify_department")]
        public string? VerifyDepartment { get; set; }

        /// <summary>
        /// 获取或设置验核机构交易流水号。
        /// </summary>
        [Newtonsoft.Json.JsonProperty("verify_department_trade_id")]
        [System.Text.Json.Serialization.JsonPropertyName("verify_department_trade_id")]
        public string? VerifyDepartmentTradeId { get; set; }
    }
}
