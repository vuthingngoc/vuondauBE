using System;
using System.Collections.Generic;
using System.Text;
using VuonDau.Data.Models;

namespace VuonDau.Business.ViewModel
{
    public class TransactionViewModel
    {
        public Guid Id { get; set; }
        public virtual OrderViewModel Order { get; set; }
        public double? Price { get; set; }
        public virtual PaymentViewModel Payment { get; set; }
        public int? Status { get; set; }
        public string Description { get; set; }
    }
}
