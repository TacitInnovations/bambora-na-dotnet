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
using System.Net;
using System.Text;
using Newtonsoft.Json;
using Bambora.NA.SDK.Data;

namespace Bambora.NA.SDK.Requests
{
    public class ExecuteWebRequest : IWebCommandSpec<string>
    {
        private readonly RequestObject _requestObject;

        public ExecuteWebRequest(RequestObject requestObject)
        {
            Url = requestObject.Url;
            _requestObject = requestObject;
        }

        public Uri Url { get; }

        public void PrepareRequest(WebRequest request)
        {
            if (!(request is HttpWebRequest httpRequest))
            {
                throw new InvalidOperationException("URL AuthType not supported: " + Url.Scheme);
            }

            httpRequest.Method = _requestObject.Method.ToString().ToUpper();
            if (_requestObject.Credentials != null) // we might use this for a no auth connection
            {
                httpRequest.Headers.Add("Authorization", GetAuthorizationHeaderString(_requestObject.Credentials));
            }

            if (!string.IsNullOrEmpty(_requestObject.SubMerchantId))
            {
                httpRequest.Headers.Add("Sub-Merchant-Id", _requestObject.SubMerchantId);
            }

            httpRequest.ContentType = "application/json";

            if (_requestObject.Data != null)
            {
                var data = JsonConvert.SerializeObject(
                    _requestObject.Data,
                    Formatting.Indented,
                    new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore } // ignore null values
                );

                using (var writer = new StreamWriter(request.GetRequestStream()))
                {
                    writer.Write(data);
                }
            }
        }

        public string MapResponse(WebResponse response)
        {
            if (response == null)
            {
                throw new Exception("Could not get a response from Bambora API");
            }

            return GetResponseBody(response);
        }

        private static string GetResponseBody(WebResponse response)
        {
            var stream = response.GetResponseStream();

            if (stream == null)
            {
                throw new Exception("Could not get a response from Bambora API");
            }

            using (var reader = new StreamReader(stream))
            {
                return reader.ReadToEnd();
            }
        }

        private static string GetAuthorizationHeaderString(Credentials credentials)
        {
            var plainAuth = Encoding.UTF8.GetBytes($"{credentials.Username}:{credentials.Password}");
            var base64Auth = Convert.ToBase64String(plainAuth);

            return $"{credentials.AuthScheme} {base64Auth}";
        }
    }
}