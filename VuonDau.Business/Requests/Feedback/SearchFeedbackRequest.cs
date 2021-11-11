using System;
using System.Collections.Generic;
using System.Text;

namespace VuonDau.Business.Requests.Feedback
{
    public class SearchFeedbackRequest
    {
        public Guid? HarvestId { get; set; }
        public int? Status { get; set; }
    }
}
