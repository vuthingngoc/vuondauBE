using System;
using System.Collections.Generic;

#nullable disable

namespace VuonDau.Data.Models
{
    public partial class Campaign
    {
        public Guid Id { get; set; }
        public Guid? HarvestSellingId { get; set; }
        public Guid? OrderId { get; set; }
        public DateTime? StartTime { get; set; }
        public DateTime? EndTime { get; set; }
        public int? MinOrderAmount { get; set; }
        public int? Status { get; set; }

        public virtual HarvestSelling HarvestSelling { get; set; }
        public virtual Order Order { get; set; }
    }
}
