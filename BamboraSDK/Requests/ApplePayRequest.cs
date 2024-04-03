using Bambora.NA.SDK.Domain;
using Newtonsoft.Json;

namespace Bambora.NA.SDK.Requests
{
    public class ApplePayRequest : PaymentRequest
    {
        public ApplePayRequest()
        {
            PaymentMethod = PaymentMethods.ApplePay;
        }
        
        [JsonProperty(PropertyName = "apple_pay")] 
        public ApplePayField ApplePay { get; set; }
    }
}