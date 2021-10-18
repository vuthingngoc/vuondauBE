﻿using System;
using System.Collections.Generic;
using System.Text;

namespace VuonDau.Business.Requests.Customer
{
    public class UpdateCustomerRequest
    {
        public Guid CustomerType { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Password { get; set; }
        public string Phone { get; set; }
        public DateTime? BirthDay { get; set; }
        public int? Gender { get; set; }
        public int? Status { get; set; }
    }
}