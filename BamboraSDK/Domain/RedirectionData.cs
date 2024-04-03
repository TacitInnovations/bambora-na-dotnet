using System.Collections.Generic;
using Newtonsoft.Json;

namespace Bambora.NA.SDK.Domain
{
    public class RedirectionData
    {
        [JsonProperty(PropertyName = "url")]
        public string Url { get; set; }

        [JsonProperty(PropertyName = "values")]
        public IDictionary<string, string> Values { get; set; }
    }
}