using Microsoft.Extensions.Localization;
using Reso.Core.Custom;
using System;
using System.Collections.Generic;
using System.Text;

namespace VuonDau.Data.Common.Constants
{
    public class MyHttpException : ErrorResponse
    {
        
        public MyHttpException(int errorCode, string message)
            :base(errorCode, message)
        {
        }
    }
}
