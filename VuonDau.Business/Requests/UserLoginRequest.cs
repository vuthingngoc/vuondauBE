using System;
using System.Collections.Generic;
using System.Text;

namespace VuonDau.Business.Requests
{
    public class UserLoginRequest
    {
        public string AccessToken { get; set; }
        public string GoogleId { get; set; }
    }
}
