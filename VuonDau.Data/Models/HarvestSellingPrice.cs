using System;
using System.Collections.Generic;

#nullable disable

namespace VuonDau.Data.Models
{
    public partial class HarvestSellingPrice
    {
        public string Id { get; set; }
        public double? Price { get; set; }
        public string HarvestSellingId { get; set; }

        public virtual HarvestSelling HarvestSelling { get; set; }
    }
}
