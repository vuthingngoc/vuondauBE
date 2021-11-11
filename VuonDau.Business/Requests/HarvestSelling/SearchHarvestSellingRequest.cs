using System;
using System.Collections.Generic;
using System.Text;
using VuonDau.Business.ViewModel;

namespace VuonDau.Business.Requests.HarvestSelling
{
    public class SearchHarvestSellingRequest
    {
        public Guid? HarvestId { get; set; }
        public Guid? ProductTypeId { get; set; }
        public DateTime? endDate { get; set; }
        public int? Status { get; set; }
    }
}
