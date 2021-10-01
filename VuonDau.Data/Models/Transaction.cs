using System;
using System.Collections.Generic;

#nullable disable

namespace VuonDau.Data.Models
{
    public partial class Transaction
    {
        public string Id { get; set; }
        public string OrderId { get; set; }
        public double? Price { get; set; }
        public string PaymentId { get; set; }
        public bool? Status { get; set; }
        public string Description { get; set; }

        public virtual Order Order { get; set; }
        public virtual Payment Payment { get; set; }
    }
}
