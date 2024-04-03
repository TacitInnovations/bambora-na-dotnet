using Newtonsoft.Json;

namespace Bambora.NA.SDK.Domain
{
    public class CardExpiryData
    {
        [JsonProperty(PropertyName = "year")]
        public string Year { get; set; }

        [JsonProperty(PropertyName = "month")]
        public string Month { get; set; }
    }
}