using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;
using System.Collections.Generic;
using System.Text;
using VuonDau.Data.Models;

namespace VuonDau.Business.ViewModel
{
    public class HarvestSellingViewModel
    {
        [BindNever]
        public Guid? Id { get; set; }
        public virtual HarvestViewModel? Harvest { get; set; }
        public virtual CampaignViewModel? Campaign { get; set; }
        public DateTime? DateOfCreate { get; set; }
        public DateTime? EndDate { get; set; }
        public double? MinWeight { get; set; }
        public double? TotalWeight { get; set; }
        public int? Status { get; set; }
    }
}
