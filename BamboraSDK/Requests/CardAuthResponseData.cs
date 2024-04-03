using Newtonsoft.Json;

namespace Bambora.NA.SDK.Requests
{
    public class CardAuthResponseData
    {
        [JsonProperty(PropertyName = "threeDS_session_data")]
        public string ThreeDSSessionData { get; set; }

        [JsonProperty(PropertyName = "cres")]
        public string Cres { get; set; }
    }
}