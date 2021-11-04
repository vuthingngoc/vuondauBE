using System;
using System.Collections.Generic;

#nullable disable

namespace VuonDau.Data.Models
{
    public partial class Campaign
    {
        public Campaign()
        {
            HarvestSellings = new HashSet<HarvestSelling>();
            Orders = new HashSet<Order>();
        }

        public Guid Id { get; set; }
        public DateTime? StartTime { get; set; }
        public DateTime? EndTime { get; set; }
        public int? MinOrderAmount { get; set; }
        public int? Status { get; set; }

        public virtual ICollection<HarvestSelling> HarvestSellings { get; set; }
        public virtual ICollection<Order> Orders { get; set; }
    }
}
