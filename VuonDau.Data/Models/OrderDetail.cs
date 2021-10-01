using System;
using System.Collections.Generic;

#nullable disable

namespace VuonDau.Data.Models
{
    public partial class OrderDetail
    {
        public string Id { get; set; }
        public string ProductId { get; set; }
        public string OrderId { get; set; }
        public double? Weight { get; set; }
        public double? Price { get; set; }
        public bool? Status { get; set; }

        public virtual Order Order { get; set; }
        public virtual Product Product { get; set; }
    }
}
