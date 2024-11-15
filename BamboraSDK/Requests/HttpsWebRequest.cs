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
using System.Globalization;
using System.IO;
using System.Net;
using System.Net.Http;
using Bambora.NA.SDK.Data;
using Bambora.NA.SDK.Domain;
using Bambora.NA.SDK.Exceptions;
using Newtonsoft.Json;
/// <summary>
/// Creates the actual web request and returns the response object.
/// It requires a merchantID and passcode to connect to the Bambora REST API.
/// </summary>
using Newtonsoft.Json.Linq;


namespace Bambora.NA.SDK.Requests
{
    public class HttpsWebRequest
    {
        private string _merchantId;
        private string _subMerchantId;
        private string _passcode;
        private IWebCommandExecutor _executor = new WebCommandExecutor();

        public int MerchantId
        {
            set => _merchantId = value.ToString(CultureInfo.InvariantCulture);
        }

        public int? SubMerchantId
        {
            set => _subMerchantId = value.ToString();
        }

        public string Passcode
        {
            set => _passcode = value;
        }

        public IWebCommandExecutor WebCommandExecutor
        {
            set => _executor = value;
        }

        public string ProcessTransaction(HttpMethod method, string url, object data = null)
        {
            try
            {
                const string authScheme = "Passcode";

                Credentials authInfo = null;
                // this request might not be using authorization
                if (_passcode != null)
                {
                    authInfo = new Credentials(_merchantId, _passcode, authScheme);
                }

                var requestInfo = new RequestObject(method, url, authInfo, _subMerchantId, data);

                var command = new ExecuteWebRequest(requestInfo);
                var result = _executor.ExecuteCommand(command);
                if (!IsSuccessStatusCode(result.ReturnValue))
                {
                    throw BamboraApiException(result);
                }

                return result.Response;
            }
            catch (HttpRequestException ex) //catch web command exception
            {
                throw new CommunicationException("Could not process the request successfully", ex);
            }
        }

        private static Exception BamboraApiException(WebCommandResult<string> result)
        {
            var statusCode = (HttpStatusCode)result.ReturnValue;
            var data = result.Response; //Get from exception

            var errorData = new ErrorData();
            if (data != null)
            {
                try
                {
                    errorData = JsonConvert.DeserializeObject<ErrorData>(data);
                }
                catch (Exception)
                {
                    // data is not json and not in the format we expect
                }
            }

            switch (statusCode)
            {
                case HttpStatusCode.Found: // 302
                    return new RedirectionException(statusCode, data, errorData.Message, errorData.Category, errorData.Code); // Used for redirection response in 3DS, Masterpass and Interac Online requests

                case HttpStatusCode.BadRequest: // 400
                    return new InvalidRequestException(statusCode, data, errorData.Message, errorData.Category, errorData.Code); // Often missing a required parameter

                case HttpStatusCode.Unauthorized: // 401
                    return new UnauthorizedException(statusCode, data, errorData.Message, errorData.Category, errorData.Code); // authentication exception

                case HttpStatusCode.PaymentRequired: // 402
                    return new BusinessRuleException(statusCode, data, errorData.Message, errorData.Category, errorData.Code); // Request failed business requirements or rejected by processor/bank

                case HttpStatusCode.Forbidden: // 403
                    return new ForbiddenException(statusCode, data, errorData.Message, errorData.Category, errorData.Code); // authorization failure

                case HttpStatusCode.NotFound: // 404
                    return new NotFoundException(statusCode, data, errorData.Message, errorData.Category, errorData.Code); // item(s) not found

                case HttpStatusCode.MethodNotAllowed: // 405
                    return new InvalidRequestException(statusCode, data, errorData.Message, errorData.Category, errorData.Code); // Sending the wrong HTTP Method

                case HttpStatusCode.UnsupportedMediaType: // 415
                    return new InvalidRequestException(statusCode, data, errorData.Message, errorData.Category, errorData.Code); // Sending an incorrect Content-Type

                default:
                    return new InternalServerException(statusCode, data, errorData.Message, errorData.Category, errorData.Code);
            }
        }

        private static bool IsSuccessStatusCode(int statusCode)
        {
            return statusCode is >= 200 and < 300;
        }
    }
}