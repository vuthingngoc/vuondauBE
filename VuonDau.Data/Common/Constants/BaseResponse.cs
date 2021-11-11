﻿using Microsoft.Extensions.Localization;

namespace VuonDau.Data.Common.Constants
{
    public class BaseResponse<T>
    {
        public int Code { get; set; }
        public T Data { get; set; }
        public string Msg { get; set; }
    }
}
