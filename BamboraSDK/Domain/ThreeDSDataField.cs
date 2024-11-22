using Newtonsoft.Json;

namespace Bambora.NA.SDK.Domain
{
    public class ThreeDSDataField
    {
        [JsonProperty(PropertyName = "version")]
        public int Version { get; set; }

        [JsonProperty(PropertyName = "auth_required")]
        public bool AuthRequired { get; set; }

        [JsonProperty(PropertyName = "enabled")]
        public bool Enabled { get; set; }

        [JsonProperty(PropertyName = "browser", DefaultValueHandling = DefaultValueHandling.IgnoreAndPopulate)]
        public BrowserData Browser { get; set; }
    }
}