using System;
using System.Collections.Generic;
using System.Text;

namespace VuonDau.Business.Requests.Transaction
{
    public class UpdateTransactionRequest
    {
        public Guid? OrderId { get; set; }
        public double? Price { get; set; }
        public Guid? PaymentId { get; set; }
        public string Description { get; set; }
        public int? Status { get; set; }
    }
}
