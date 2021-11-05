using System;
using System.Collections.Generic;
using System.Text;

namespace VuonDau.Business.Requests.Order
{
    public class CreateOrderRequest
    {
        public Guid? CustomerId { get; set; }
        public Guid? CampaignId { get; set; }
        public string FullName { get; set; }
        public string Message { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }
        public double? TotalPrice { get; set; }

    }
}
