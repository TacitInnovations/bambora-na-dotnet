using Newtonsoft.Json;

namespace Bambora.NA.SDK.Requests
{
    public class AndroidPayRequest : PaymentRequest
    {
        public AndroidPayRequest()
        {
            PaymentMethod = PaymentMethods.android_pay.ToString();
        }
        
        [JsonProperty(PropertyName = "android_pay")] 
        public AndroidPayField AndroidPay { get; set; }
    }
}