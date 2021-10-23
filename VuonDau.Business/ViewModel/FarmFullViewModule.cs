using System;
using System.Collections.Generic;
using System.Text;
using VuonDau.Data.Models;

namespace VuonDau.Business.ViewModel
{
    public class FarmFullViewModel
    {
        public Guid Id { get; set; }
        public virtual FarmType FarmType { get; set; }
        public virtual Farmer Farmer { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string Description { get; set; }
        public DateTime? DateOfCreate { get; set; }
        public DateTime? DateUpdate{ get; set; }
        public int? Status { get; set; }
    }
}
