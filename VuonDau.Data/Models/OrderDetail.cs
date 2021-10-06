using System;
using System.Collections.Generic;

#nullable disable

namespace VuonDau.Data.Models
{
    public partial class OrderDetail
    {
        public int Id { get; set; }
        public int? ProductId { get; set; }
        public int? OrderId { get; set; }
        public double? Weight { get; set; }
        public double? Price { get; set; }
        public int? Status { get; set; }

        public virtual Order Order { get; set; }
        public virtual Product Product { get; set; }
    }
}
