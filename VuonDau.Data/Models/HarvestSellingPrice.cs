using System;
using System.Collections.Generic;

#nullable disable

namespace VuonDau.Data.Models
{
    public partial class HarvestSellingPrice
    {
        public int Id { get; set; }
        public double? Price { get; set; }
        public int? HarvestSellingId { get; set; }

        public virtual HarvestSelling HarvestSelling { get; set; }
    }
}
