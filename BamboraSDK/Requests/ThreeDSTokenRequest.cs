using Bambora.NA.SDK.Domain;
using Newtonsoft.Json;

namespace Bambora.NA.SDK.Requests
{
    public class ThreeDSTokenRequest : PaymentRequest
    {
        public ThreeDSTokenRequest()
        {
            PaymentMethod = PaymentMethods.ThreeDSToken;
        }

        [JsonProperty(PropertyName = "3d_secure_token")]
        public ThreeDSTokenField ThreeDSToken { get; set; }
    }
}