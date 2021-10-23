using System;
using System.Collections.Generic;
using System.Text;
using VuonDau.Data.Models;

namespace VuonDau.Business.ViewModel
{
    public class OrderViewModel
    {
        public Guid Id { get; set; }
        public virtual CustomerViewModel Customer { get; set; }
        public DateTime? DateOfCreate { get; set; }
        public string Address { get; set; }
        public double? TotalPrice { get; set; }
        public int? Status { get; set; }
    }
}
