using System;
using System.Collections.Generic;
using System.Text;

namespace VuonDau.Business.ViewModel
{
    public class TransactionViewModel
    {
        public Guid Id { get; set; }
        public Guid? OrderId { get; set; }
        public double? Price { get; set; }
        public Guid? PaymentId { get; set; }
        public int? Status { get; set; }
        public string Description { get; set; }
    }
}
