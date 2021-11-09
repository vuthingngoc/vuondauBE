﻿using System;
using System.Collections.Generic;
using System.Text;

namespace VuonDau.Business.Requests.Feedback
{
    public class UpdateFeedbackRequest
    {
        public Guid? OrderId { get; set; }
        public Guid? HarvestId { get; set; }
        public Guid? FarmerId { get; set; }
        public string Description { get; set; }
        public int? Status { get; set; }
    }
}
