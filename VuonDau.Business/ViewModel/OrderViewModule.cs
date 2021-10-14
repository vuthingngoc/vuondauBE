using System;
using System.Collections.Generic;
using System.Text;

namespace VuonDau.Business.ViewModel
{
    public class OrderViewModel
    {
        public Guid Id { get; set; }
        public Guid? CustomerId { get; set; }
        public DateTime? DateOfCreate { get; set; }
        public string Address { get; set; }
        public double? TotalPrice { get; set; }
        public int? Status { get; set; }
    }
}
