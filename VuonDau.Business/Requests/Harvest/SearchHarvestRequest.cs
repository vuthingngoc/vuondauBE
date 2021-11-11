using System;
using System.Collections.Generic;
using System.Text;

namespace VuonDau.Business.Requests.Harvest
{
    public class SearchHarvestRequest
    {
        public Guid? FarmId { get; set; }
        public Guid? ProductTypeId { get; set; }
        public string Name { get; set; }
        public DateTime? Date { get; set; }
        public int? Status { get; set; }
    }
}
