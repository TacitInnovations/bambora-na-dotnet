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

using System;
using System.Net.Http;

namespace Bambora.NA.SDK.Requests
{
    public class RequestObject
    {
        public RequestObject(HttpMethod method, string url, Credentials credentials, object data)
            : this(method, url, credentials, null, data)
        {
        }

        public RequestObject(HttpMethod method, string url, Credentials credentials, string subMerchantId, object data)
        {
            Method = method;
            Url = new Uri(url);
            Credentials = credentials;
            SubMerchantId = subMerchantId;
            Data = data;
        }

        public object Data { get; }
        
        public HttpMethod Method { get; }
        
        public Uri Url { get; }
        
        public Credentials Credentials { get; }
        
        public string SubMerchantId { get; }
    }
}