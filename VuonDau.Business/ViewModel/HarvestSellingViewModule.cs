﻿using System;
using System.Collections.Generic;
using System.Text;

namespace VuonDau.Business.ViewModel
{
    public class HarvestSellingViewModel
    {
        public Guid Id { get; set; }
        public Guid? HarvestId { get; set; }
        public DateTime? DateOfCreate { get; set; }
        public double? MinWeight { get; set; }
        public double? TotalWeight { get; set; }
    }
}