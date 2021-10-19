using System;
using System.Collections.Generic;

#nullable disable

namespace VuonDau.Data.Models
{
    public partial class OrderDetail
    {
        public Guid Id { get; set; }
        public Guid? HarvestsellingId { get; set; }
        public Guid? OrderId { get; set; }
        public double? Weight { get; set; }
        public double? Price { get; set; }
        public int? Status { get; set; }

        public virtual HarvestSelling Harvestselling { get; set; }
        public virtual Order Order { get; set; }
    }
}
