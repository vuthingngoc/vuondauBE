using System;
using System.Collections.Generic;
using System.Text;

namespace VuonDau.Business.Requests.HarvestSelling
{
    public class UpdateHarvestSellingRequest
    {
        public Guid? HarvestId { get; set; }
        public double? MinWeight { get; set; }
        public double? TotalWeight { get; set; }
    }
}
