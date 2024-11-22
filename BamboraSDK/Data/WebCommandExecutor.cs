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
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Bambora.NA.SDK.Exceptions;


namespace Bambora.NA.SDK.Data
{
    /// <summary>
    /// Executes web requests. This piece of code is pulled out from HttpWebRequest
    /// (which does the heavy lifting of the actual request) so that we can plug in
    /// mock responses for unit testing.
    /// </summary>
    public class WebCommandExecutor : IWebCommandExecutor
    {
        private readonly Func<HttpClient> _httpClientFactory;
        private readonly Lazy<HttpClient> _httpClient = new(() => new HttpClient());

        public WebCommandExecutor(Func<HttpClient> httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public WebCommandExecutor()
        {
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls12;
            _httpClientFactory = GetHttpClient;
        }

        public WebCommandResult<T> ExecuteCommand<T>(IWebCommandSpec<T> spec)
        {
            return ExecuteCommandAsync(spec)
                .GetAwaiter()
                .GetResult();
        }

        private async Task<WebCommandResult<T>> ExecuteCommandAsync<T>(IWebCommandSpec<T> spec)
        {
            if (spec == null)
            {
                throw new ArgumentNullException(nameof(spec));
            }

            var result = new WebCommandResult<T>();

            var client = _httpClientFactory();
            var request = new HttpRequestMessage();
            spec.PrepareRequest(request);
            var response = await client.SendAsync(request)
                .ConfigureAwait(false);
            if (response == null)
            {
                throw new BamboraException("Could not get a response from Bambora API");
            }

            result.ReturnValue = (int)response.StatusCode;
            result.Response = await spec.MapResponseAsync(response)
                .ConfigureAwait(false);

            return result;
        }

        private HttpClient GetHttpClient() => _httpClient.Value;
    }
}