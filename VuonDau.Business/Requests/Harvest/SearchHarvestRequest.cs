using System;
using System.Collections.Generic;
using System.Text;

namespace VuonDau.Business.Requests.Harvest
{
    public class SearchHarvestRequest
    {
        public Guid? FarmId { get; set; }
        public string Name { get; set; }
        public int? Status { get; set; }
    }
}
