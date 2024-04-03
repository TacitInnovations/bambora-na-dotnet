using System;
using Bambora.NA.SDK.Domain;
using Newtonsoft.Json;

namespace Bambora.NA.SDK
{
    public class CardAuthDataResponse
    {
        [JsonProperty(PropertyName = "threeDS_session_data")]
        public string ThreeDSSessionData { get; set; }

        [JsonProperty(PropertyName = "transaction_id")]
        public string TransactionId { get; set; }

        [JsonProperty(PropertyName = "amount")]
        public decimal Amount { get; set; }

        [JsonProperty(PropertyName = "card")]
        public CardDataEx Card { get; set; }

        [JsonProperty(PropertyName = "flow_type")]
        public string FlowType { get; set; }

        [JsonProperty(PropertyName = "status")]
        public string Status { get; set; }

        [JsonProperty(PropertyName = "authorization")]
        public AuthorizationData Authorization { get; set; }

        [JsonProperty(PropertyName = "error")]
        public string Error { get; set; }

        [JsonProperty(PropertyName = "created_datetime_utc")]
        public DateTime CreatedDatetimeUtc { get; set; }
    }
}