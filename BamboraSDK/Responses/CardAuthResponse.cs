using System.Collections.Generic;
using Bambora.NA.SDK.Domain;
using Newtonsoft.Json;

namespace Bambora.NA.SDK
{
    public class CardAuthResponse
    {
        [JsonProperty(PropertyName = "threeDS_session_data")]
        public string ThreeDSSessionData { get; set; }

        [JsonProperty(PropertyName = "redirection")]
        public RedirectionData Redirection { get; set; }

        [JsonProperty(PropertyName = "authorization")]
        public AuthorizationData Authorization { get; set; }

        [JsonProperty(PropertyName = "status")]
        public string Status { get; set; }

        [JsonProperty(PropertyName = "type")]
        public string Type { get; set; }

        [JsonProperty(PropertyName = "message")]
        public string Message { get; set; }

        [JsonProperty(PropertyName = "details")]
        public ICollection<string> Details { get; set; }
    }
}