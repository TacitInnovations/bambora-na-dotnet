using Bambora.NA.SDK.Domain;
using Newtonsoft.Json;

namespace Bambora.NA.SDK.Requests
{
    public class AndroidPayRequest : PaymentRequest
    {
        public AndroidPayRequest()
        {
            PaymentMethod = PaymentMethods.AndroidPay;
        }
        
        [JsonProperty(PropertyName = "android_pay")] 
        public AndroidPayField AndroidPay { get; set; }
    }
}