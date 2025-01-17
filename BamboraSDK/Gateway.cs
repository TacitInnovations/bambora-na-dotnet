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

using Bambora.NA.SDK.Data;

/// <summary>
/// The entry-point into making payments and handling payment profiles.
/// 
/// This gives you access to the PaymentsAPI, ProfilesAPI, and the ReportingAPI.
/// 
/// Each API requires its own API key that you can obtain in the member area of your 
/// Bambora account https://web.na.bambora.com/admin/sDefault.asp
/// 
/// You must set the MerchantID and one of the API keys before you use this class.
/// Exceptions will the thrown otherwise.
/// 
/// The login credentials are stored in a Configuration object.
/// 
/// This class is not threadsafe but designed to have its own instance per thread. If you 
/// are making payments through multiple threads you want to create one Gateway object per thread.
/// </summary>
namespace Bambora.NA.SDK
{
    public class Gateway
    {
        /// <summary>
        /// The Beanstream merchant ID 
        /// </summary>
        public int MerchantId
        {
            get => Configuration.MerchantId;
            set => Configuration.MerchantId = value;
        }

        /// <summary>
        ///  Only used by partners to make an API call on behalf of their subMerchant.
        /// </summary>
        public int? SubMerchantId
        {
            get => Configuration.SubMerchantId;
            set => Configuration.SubMerchantId = value;
        }

        /// <summary>
        /// The API Key (Passcode) for accessing the payments API.
        /// </summary>
        public string PaymentsApiKey
        {
            set => Configuration.PaymentsApiPasscode = value;
            get => Configuration.PaymentsApiPasscode;
        }

        /// <summary>
        /// The API Key (Passcode) for accessing the reporting API.
        /// </summary>
        public string ReportingApiKey
        {
            set => Configuration.ReportingApiPasscode = value;
            get => Configuration.ReportingApiPasscode;
        }

        /// <summary>
        /// The API Key (Passcode) for accessing the profiles API.
        /// </summary>
        public string ProfilesApiKey
        {
            set => Configuration.ProfilesApiPasscode = value;
            get => Configuration.ProfilesApiPasscode;
        }

        /// <summary>
        /// The api version to use
        /// </summary>
        public string ApiVersion
        {
            get => Configuration.Version;
            set => Configuration.Version = value;
        }

        private Configuration _configuration;

        public Configuration Configuration => _configuration ?? (_configuration = new Configuration());

        public IWebCommandExecutor WebCommandExecutor { get; set; }

        private PaymentsAPI _payments;

        public PaymentsAPI Payments
        {
            get
            {
                if (_payments == null)
                {
                    _payments = new PaymentsAPI();
                }

                _payments.Configuration = Configuration;
                if (WebCommandExecutor != null)
                {
                    _payments.WebCommandExecutor = WebCommandExecutor;
                }

                return _payments;
            }
        }


        private ReportingAPI _reporting;

        public ReportingAPI Reporting
        {
            get
            {
                if (_reporting == null)
                {
                    _reporting = new ReportingAPI();
                }

                _reporting.Configuration = Configuration;
                if (WebCommandExecutor != null)
                {
                    _reporting.WebCommandExecutor = WebCommandExecutor;
                }

                return _reporting;
            }
        }


        private ProfilesAPI _profiles;

        public ProfilesAPI Profiles
        {
            get
            {
                if (_profiles == null)
                {
                    _profiles = new ProfilesAPI();
                }

                _profiles.Configuration = Configuration;
                if (WebCommandExecutor != null)
                {
                    _profiles.WebCommandExecutor = WebCommandExecutor;
                }

                return _profiles;
            }
        }


        public static void ThrowIfNullArgument(object value, string name)
        {
            if (value == null)
            {
                throw new System.ArgumentNullException(name);
            }
        }
    }
}