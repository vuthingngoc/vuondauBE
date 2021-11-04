using System;
using System.Collections.Generic;
using System.Text;

namespace VuonDau.Business.Requests.HarvestSelling
{
    public class CreateHarvestSellingRequest
    {
        public Guid? HarvestId { get; set; }
        public Guid? CampaignId { get; set; }
        public DateTime? DateOfCreate { get; set; }
        public DateTime? EndDate { get; set; }
        public double? MinWeight { get; set; }
        public double? TotalWeight { get; set; }

    }
}
