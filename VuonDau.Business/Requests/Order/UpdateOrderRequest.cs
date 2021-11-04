﻿using System;
using System.Collections.Generic;
using System.Text;

namespace VuonDau.Business.Requests.Order
{
    public class UpdateOrderRequest
    {
        public Guid? CustomerId { get; set; }
        public string Address { get; set; }
        public double? TotalPrice { get; set; }
        public int? Status { get; set; }
    }
}
