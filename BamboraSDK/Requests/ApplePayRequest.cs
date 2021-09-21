using Newtonsoft.Json;

namespace Bambora.NA.SDK.Requests
{
    public class ApplePayRequest : PaymentRequest
    {
        public ApplePayRequest()
        {
            PaymentMethod = PaymentMethods.apple_pay.ToString();
        }
        
        [JsonProperty(PropertyName = "apple_pay")] 
        public ApplePayField ApplePay { get; set; }
    }
}