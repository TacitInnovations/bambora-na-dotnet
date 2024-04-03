using Newtonsoft.Json;

namespace Bambora.NA.SDK.Domain;

public class CardDataEx
{
    [JsonProperty(PropertyName = "bin")]
    public string Bin { get; set; }

    [JsonProperty(PropertyName = "last_four")]
    public string LastFour { get; set; }

    [JsonProperty(PropertyName = "expiry_month")]
    public string ExpiryMonth { get; set; }

    [JsonProperty(PropertyName = "expiry_year")]
    public string ExpiryYear { get; set; }
}