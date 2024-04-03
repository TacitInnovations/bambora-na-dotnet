using Newtonsoft.Json;

namespace Bambora.NA.SDK.Domain
{
    public class BrowserData
    {
        [JsonProperty(PropertyName = "accept_header")]
        public string AcceptHeader { get; set; }

        [JsonProperty(PropertyName = "ip_address")]
        public string IpAddress { get; set; }

        [JsonProperty(PropertyName = "java_enabled")]
        public bool JavaEnabled { get; set; }

        [JsonProperty(PropertyName = "javascript_enabled")]
        public bool JavascriptEnabled { get; set; }

        [JsonProperty(PropertyName = "language")]
        public string Language { get; set; }

        [JsonProperty(PropertyName = "color_depth")]
        public int ColorDepth { get; set; }

        [JsonProperty(PropertyName = "screen_width")]
        public int ScreenWidth { get; set; }

        [JsonProperty(PropertyName = "screen_height")]
        public int ScreenHeight { get; set; }

        [JsonProperty(PropertyName = "time_zone")]
        public int TimeZone { get; set; }

        [JsonProperty(PropertyName = "user_agent")]
        public string UserAgent { get; set; }
    }
}