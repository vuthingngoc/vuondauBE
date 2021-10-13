using System;
using System.Collections.Generic;

#nullable disable

namespace VuonDau.Data.Models
{
    public partial class HarvestSellingPrice
    {
        public Guid Id { get; set; }
        public double? Price { get; set; }
        public Guid? HarvestSellingId { get; set; }

        public virtual HarvestSelling HarvestSelling { get; set; }
    }
}
