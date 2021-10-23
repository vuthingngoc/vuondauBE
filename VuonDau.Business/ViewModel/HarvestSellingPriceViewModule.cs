using System;
using System.Collections.Generic;
using System.Text;
using VuonDau.Data.Models;

namespace VuonDau.Business.ViewModel
{
    public class HarvestSellingPriceViewModel
    {
        public Guid Id { get; set; }
        public double? Price { get; set; }
        public virtual HarvestSellingViewModel HarvestSelling { get; set; }
        public int? Status { get; set; }
    }
}
