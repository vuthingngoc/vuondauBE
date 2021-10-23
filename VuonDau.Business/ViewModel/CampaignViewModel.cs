using System;
using System.Collections.Generic;
using System.Text;
using VuonDau.Data.Models;

namespace VuonDau.Business.ViewModel
{
    public class CampaignViewModel
    {
        public Guid Id { get; set; }
        public virtual HarvestSellingViewModel HarvestSelling { get; set; }
        public virtual OrderViewModel Order { get; set; }
        public DateTime? StartTime { get; set; }
        public DateTime? EndTime { get; set; }
        public int? MinOrderAmount { get; set; }
        public int? Status { get; set; }

    }
}
