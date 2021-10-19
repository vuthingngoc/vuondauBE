using System;
using System.Collections.Generic;
using System.Text;

namespace VuonDau.Business.ViewModel
{
    public class HarvestSellingPriceViewModel
    {
        public Guid Id { get; set; }
        public double? Price { get; set; }
        public Guid? HarvestSellingId { get; set; }
        public int? Status { get; set; }
    }
}
