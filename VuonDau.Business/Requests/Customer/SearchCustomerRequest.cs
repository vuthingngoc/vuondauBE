using System;
using System.Collections.Generic;
using System.Text;

namespace VuonDau.Business.Requests.Customer
{
    public class SearchCustomerRequest
    {
        public string Email { get; set; }
        public string FullName { get; set; }
        public int? Status { get; set; }
    }
}
