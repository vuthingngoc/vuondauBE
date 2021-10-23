using System;
using System.Collections.Generic;
using System.Text;
using VuonDau.Data.Models;

namespace VuonDau.Business.ViewModel
{
    public class OrderDetailViewModel
    {
        public Guid Id { get; set; }
        public virtual HarvestSellingViewModel Harvestselling { get; set; }
        public virtual OrderViewModel Order { get; set; }
        public double? Weight { get; set; }
        public double? Price { get; set; }
        public int? Status { get; set; }
    }
}
