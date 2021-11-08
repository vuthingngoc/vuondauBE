using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;
using System.Collections.Generic;
using System.Text;
using VuonDau.Data.Models;

namespace VuonDau.Business.ViewModel
{
    public class FeedbackViewModel
    {
        [BindNever]
        public Guid? Id { get; set; }
        public virtual OrderViewModel? Order { get; set; }
        public virtual HarvestViewModel? Harvest { get; set; }
        public virtual FarmerViewModel? Farmer { get; set; }
        public DateTime? DateOfCreate { get; set; }
        public string Description { get; set; }
        public int? Status { get; set; }
    }
}
