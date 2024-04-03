using Newtonsoft.Json;

namespace Bambora.NA.SDK.Domain
{
    public class AuthorizationData
    {
        [JsonProperty(PropertyName = "eci")]
        public string Eci { get; set; }

        [JsonProperty(PropertyName = "cavv")]
        public string Cavv { get; set; }

        [JsonProperty(PropertyName = "xid")]
        public string Xid { get; set; }

        [JsonProperty(PropertyName = "ds_transaction_id")]
        public string DsTransactionId { get; set; }

        [JsonProperty(PropertyName = "protocol_version")]
        public string ProtocolVersion { get; set; }
    }
}