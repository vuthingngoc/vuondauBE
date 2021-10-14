using System;
using System.Collections.Generic;
using System.Text;

namespace VuonDau.Business.Requests.HarvestSellingPrice
{
    public class CreateHarvestSellingPriceRequest
    {
        public double? Price { get; set; }
        public Guid? HarvestSellingId { get; set; }

    }
}
