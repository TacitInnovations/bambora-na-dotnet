using Newtonsoft.Json;

namespace Bambora.NA.SDK.Domain
{
    public class ThreeDSTokenField
    {
        public ThreeDSTokenField()
        {
            Complete = true;
        }

        [JsonProperty(PropertyName = "threeDS_session_data")]
        public string ThreeDSSessionData { get; set; }

        [JsonProperty(PropertyName = "complete")]
        public bool Complete { get; set; }
    }
}