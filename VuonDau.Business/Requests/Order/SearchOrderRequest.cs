using System;
using System.Collections.Generic;
using System.Text;

namespace VuonDau.Business.Requests.Order
{
    public class SearchOrderRequest
    {
        public Guid? CustomerId { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public int? Status { get; set; }
    }
}
