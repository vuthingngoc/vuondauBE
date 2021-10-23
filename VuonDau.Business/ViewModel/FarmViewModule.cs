using System;
using System.Collections.Generic;
using System.Text;
using VuonDau.Data.Models;

namespace VuonDau.Business.ViewModel
{
    public class FarmViewModel
    {
        public Guid Id { get; set; }
        public virtual FarmTypeViewModel FarmType { get; set; }
        public virtual FarmerViewModel Farmer { get; set; }
        public virtual AreaViewModel Area { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string Description { get; set; }
        public DateTime? DateOfCreate { get; set; }
        public DateTime? DateUpdate { get; set; }
        public int? Status { get; set; }
    }
}
