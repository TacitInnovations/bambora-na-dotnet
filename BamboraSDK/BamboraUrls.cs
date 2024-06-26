﻿// The MIT License (MIT)
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

namespace Bambora.NA.SDK
{
    public class BamboraUrls
    {
        public static string BaseUrl => "https://{p}.bambora.com";
        public static string BaseUrlVersion => BaseUrl + "/{v}";
        public static string BasePaymentsUrl => BaseUrlVersion + "/payments";
        public static string BaseProfilesUrl => BaseUrlVersion + "/profiles";
        public static string ProfileUrl => BaseProfilesUrl + "/{pid}";
        public static string PreAuthCompletionsUrl => BasePaymentsUrl + "/{id}/completions";
        public static string ReturnsUrl => BasePaymentsUrl + "/{id}/returns";
        public static string VoidsUrl => BasePaymentsUrl + "/{id}/void";
        public static string GetPaymentUrl => BasePaymentsUrl + "/{id}";
        public static string ContinuationsUrl => BasePaymentsUrl + "/{md}/continue";
        public static string ReportsUrl => BaseUrlVersion + "/reports";
        public static string CardsUrl => ProfileUrl + "/cards";
        public static string CardUrl => CardsUrl + "/{cid}";
        public static string TokenUrl => BaseUrl + "/scripts/tokenization/tokens";
        public static string BaseCardAuthUrl => BaseUrlVersion + "/EMV3DS";
        public static string CardAuthRequestUrl => BaseCardAuthUrl + "/AuthRequest";
        public static string CardAuthResponseUrl => BaseCardAuthUrl + "/AuthResponse";
        public static string CardAuthDataUrl => BaseCardAuthUrl + "/{sd}";
    }
}