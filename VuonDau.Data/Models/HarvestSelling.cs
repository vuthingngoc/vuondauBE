using System;
using System.Collections.Generic;

#nullable disable

namespace VuonDau.Data.Models
{
    public partial class HarvestSelling
    {
        public HarvestSelling()
        {
            CustomerGroups = new HashSet<CustomerGroup>();
            HarvestSellingPrices = new HashSet<HarvestSellingPrice>();
        }

        public Guid Id { get; set; }
        public Guid? HarvestId { get; set; }
        public DateTime? DateOfCreate { get; set; }
        public double? MinWeight { get; set; }
        public double? TotalWeight { get; set; }

        public virtual Harvest Harvest { get; set; }
        public virtual ICollection<CustomerGroup> CustomerGroups { get; set; }
        public virtual ICollection<HarvestSellingPrice> HarvestSellingPrices { get; set; }
    }
}
