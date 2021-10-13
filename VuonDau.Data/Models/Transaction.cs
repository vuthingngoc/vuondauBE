using System;
using System.Collections.Generic;

#nullable disable

namespace VuonDau.Data.Models
{
    public partial class Transaction
    {
        public Guid Id { get; set; }
        public Guid? OrderId { get; set; }
        public double? Price { get; set; }
        public Guid? PaymentId { get; set; }
        public int? Status { get; set; }
        public string Description { get; set; }

        public virtual Order Order { get; set; }
        public virtual Payment Payment { get; set; }
    }
}
