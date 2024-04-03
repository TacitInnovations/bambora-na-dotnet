using Bambora.NA.SDK.Domain;
using Newtonsoft.Json;

namespace Bambora.NA.SDK.Requests
{
    public class CardAuthRequestData
    {
        [JsonProperty(PropertyName = "browser")]
        public BrowserData Browser { get; set; }

        [JsonProperty(PropertyName = "redirect_url")]
        public string RedirectUrl { get; set; }

        [JsonProperty(PropertyName = "amount")]
        public decimal Amount { get; set; }

        [JsonProperty(PropertyName = "card", DefaultValueHandling = DefaultValueHandling.IgnoreAndPopulate)]
        public CardData Card { get; set; }

        [JsonProperty(PropertyName = "payment_profile", DefaultValueHandling = DefaultValueHandling.IgnoreAndPopulate)]
        public PaymentProfileField PaymentProfile { get; set; }

        [JsonProperty(PropertyName = "token", DefaultValueHandling = DefaultValueHandling.IgnoreAndPopulate)]
        public string Token { get; set; }

        [JsonProperty(PropertyName = "reference")]
        public string Reference { get; set; }
    }
}