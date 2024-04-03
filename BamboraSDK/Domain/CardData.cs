using Newtonsoft.Json;

namespace Bambora.NA.SDK.Domain
{
    public class CardData
    {
        [JsonProperty(PropertyName = "number")]
        public string Number { get; set; }

        [JsonProperty(PropertyName = "expiry")]
        public CardExpiryData Expiry { get; set; }
    }
}