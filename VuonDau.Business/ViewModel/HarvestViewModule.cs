using System;
using System.Collections.Generic;
using System.Text;
using VuonDau.Data.Models;

namespace VuonDau.Business.ViewModel
{
    public class HarvestViewModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public virtual FarmViewModel Farm { get; set; }
        public virtual ProductViewModel Product { get; set; }
        public string Description { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public int? Status { get; set; }
    }
}
