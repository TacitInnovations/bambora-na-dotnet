// The MIT License (MIT)
//
// Copyright (c) 2018 Bambora, Inc.
//
// Permission is hereby granted, free of charge, to any person obtaining a copy
// of this software and associated documentation files (the "Software"), to deal
// in the Software without restriction, including without limitation the rights
// to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
// copies of the Software, and to permit persons to whom the Software is
// furnished to do so, subject to the following conditions:
//
// The above copyright notice and this permission notice shall be included in
// all copies or substantial portions of the Software.
//
// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
// IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
// FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
// AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
// LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
// OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN
// THE SOFTWARE.
//

using Newtonsoft.Json;

namespace Bambora.NA.SDK
{
    public class InteracRedirectResponse
    {
        [JsonProperty(PropertyName = "funded")]
        public bool Funded { get; set; }

        [JsonProperty(PropertyName = "idebit_track2")]
        public string IdebitTrack2 { get; set; }

        [JsonProperty(PropertyName = "idebit_isslang")]
        public string IdebitIsslang { get; set; }

        [JsonProperty(PropertyName = "idebit_version")]
        public string IdebitVersion { get; set; }

        [JsonProperty(PropertyName = "idebit_issconf")]
        public string IdebitIssconf { get; set; }

        [JsonProperty(PropertyName = "idebit_issname")]
        public string IdebitIssname { get; set; }

        [JsonProperty(PropertyName = "idebit_amount")]
        public string IdebitAmount { get; set; }

        [JsonProperty(PropertyName = "idebit_invoice")]
        public string IdebitInvoice { get; set; }
    }
}