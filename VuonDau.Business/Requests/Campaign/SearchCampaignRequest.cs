using System;
using System.Collections.Generic;
using System.Text;

namespace VuonDau.Business.Requests.Campaign
{
    public class SearchCampaignRequest
    {
        public DateTime? StartTime { get; set; }
        public DateTime? EndTime { get; set; }
        public int? MinOrderAmount { get; set; }
        public int? Status { get; set; }
    }
}
