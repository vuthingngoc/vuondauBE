using System;
using System.Collections.Generic;
using System.Text;

namespace VuonDau.Business.ViewModel
{
    public class OrderDetailViewModel
    {
        public Guid Id { get; set; }
        public Guid? HarvestsellingId { get; set; }
        public Guid? OrderId { get; set; }
        public double? Weight { get; set; }
        public double? Price { get; set; }
        public int? Status { get; set; }
    }
}
