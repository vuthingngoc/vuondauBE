﻿using System;
using System.Collections.Generic;
using System.Text;

namespace VuonDau.Business.Requests.Campaign
{
    public class CreateCampaignRequest
    {
        public Guid Id { get; set; }
        public Guid? HarvestSellingId { get; set; }
        public Guid? OrderId { get; set; }
        public DateTime? StartTime { get; set; }
        public DateTime? EndTime { get; set; }
        public int? MinOrderAmount { get; set; }

    }
}