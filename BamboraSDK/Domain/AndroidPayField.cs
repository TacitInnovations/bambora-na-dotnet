using Newtonsoft.Json;

namespace Bambora.NA.SDK.Domain
{
    public class AndroidPayField
    {
        public AndroidPayField()
        {
            Complete = true;
        }
        
        [JsonProperty(PropertyName = "android_pay_merchant_id")] 
        public string AndroidPayMerchantId { get; set; }
        
        [JsonProperty(PropertyName = "payment_token")] 
        public string PaymentToken { get; set; }
        
        [JsonProperty(PropertyName = "complete")] 
        public bool Complete { get; set; }
    }
}