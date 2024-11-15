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

using System;
using System.IO;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Bambora.NA.SDK.Data;
using Bambora.NA.SDK.Exceptions;

namespace Bambora.NA.SDK.Requests
{
    public class ExecuteWebRequest : IWebCommandSpec<string>
    {
        private static readonly Encoding Encoding = Encoding.UTF8;
        
        private static readonly JsonSerializerSettings SerializerSettings = new()
        {
            Formatting = Formatting.Indented,
            NullValueHandling = NullValueHandling.Ignore,
        };
        
        private readonly RequestObject _requestObject;

        public ExecuteWebRequest(RequestObject requestObject)
        {
            Url = requestObject.Url;
            _requestObject = requestObject;
        }

        public Uri Url { get; }

        public void PrepareRequest(HttpRequestMessage httpRequest)
        {
            if (httpRequest is null)
            {
                throw new BamboraException("URL AuthType not supported: " + Url.Scheme);
            }

            httpRequest.Method = _requestObject.Method;
            httpRequest.RequestUri = Url;
            if (_requestObject.Credentials != null) // we might use this for a no auth connection
            {
                httpRequest.Headers.Add("Authorization", GetAuthorizationHeaderString(_requestObject.Credentials));
            }

            if (!string.IsNullOrEmpty(_requestObject.SubMerchantId))
            {
                httpRequest.Headers.Add("Sub-Merchant-Id", _requestObject.SubMerchantId);
            }

            if (_requestObject.Data != null)
            {
                var requestBody = JsonConvert.SerializeObject(
                    _requestObject.Data,
                    SerializerSettings
                );
                httpRequest.Content = new StringContent(requestBody, Encoding, "application/json");
            }
        }

        public async Task<string> MapResponseAsync(HttpResponseMessage response)
        {
            if (response == null)
            {
                throw new BamboraException("Could not get a response from Bambora API");
            }

            return await GetResponseBodyAsync(response.Content)
                .ConfigureAwait(false);
        }

        private static async Task<string> GetResponseBodyAsync(HttpContent content)
        {
            var stream = await content.ReadAsStreamAsync()
                .ConfigureAwait(false);
            if (stream == null)
            {
                throw new BamboraException("Could not get a response from Bambora API");
            }

            using var reader = new StreamReader(stream, Encoding, true, 1024, leaveOpen: true);
            return await reader.ReadToEndAsync()
                .ConfigureAwait(false);
        }

        private static string GetAuthorizationHeaderString(Credentials credentials)
        {
            var plainAuth = Encoding.GetBytes($"{credentials.Username}:{credentials.Password}");
            var base64Auth = Convert.ToBase64String(plainAuth);

            return $"{credentials.AuthScheme} {base64Auth}";
        }
    }
}