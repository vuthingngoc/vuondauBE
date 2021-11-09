using System;
using System.Collections.Generic;
using System.Text;

namespace VuonDau.Business.Requests.HarvestSellingPrice
{
    public class SearchHarvestSellingPriceRequest
    {
        public Guid? HarvesrSellingId { get; set; }
        public double? startPrice { get; set; }
        public double? endPrice { get; set; }
    }
}
