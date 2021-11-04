using System;
using System.Collections.Generic;
using System.Text;

namespace VuonDau.Business.Requests.Harvest
{
    public class UpdateHarvestRequest
    {
        public string Name { get; set; }
        public Guid? FarmId { get; set; }
        public Guid? ProductId { get; set; }
        public string Description { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public int? Status { get; set; }
    }
}
