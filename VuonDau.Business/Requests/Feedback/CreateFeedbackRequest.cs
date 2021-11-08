using System;
using System.Collections.Generic;
using System.Text;

namespace VuonDau.Business.Requests.Feedback
{
    public class CreateFeedbackRequest
    {
        public Guid? OrderId { get; set; }
        public Guid? HarvestId { get; set; }
        public Guid? FarmerId { get; set; }
        public string Description { get; set; }

    }
}
