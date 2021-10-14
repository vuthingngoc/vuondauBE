using System;
using System.Collections.Generic;
using System.Text;

namespace VuonDau.Business.Requests.OrderDetail
{
    public class CreateOrderDetailRequest
    {
        public Guid? ProductId { get; set; }
        public Guid? OrderId { get; set; }
        public double? Weight { get; set; }
        public double? Price { get; set; }

    }
}
