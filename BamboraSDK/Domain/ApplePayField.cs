using Newtonsoft.Json;

namespace Bambora.NA.SDK.Domain
{
    public class ApplePayField
    {
        public ApplePayField()
        {
            Complete = true;
        }
        
        [JsonProperty(PropertyName = "apple_pay_merchant_id")] 
        public string ApplePayMerchantId { get; set; }
        
        [JsonProperty(PropertyName = "payment_token")] 
        public string PaymentToken { get; set; }
        
        [JsonProperty(PropertyName = "complete")] 
        public bool Complete { get; set; }
    }
}