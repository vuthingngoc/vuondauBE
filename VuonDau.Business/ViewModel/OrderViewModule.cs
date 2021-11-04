using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;
using System.Collections.Generic;
using System.Text;
using VuonDau.Data.Models;

namespace VuonDau.Business.ViewModel
{
    public class OrderViewModel
    {
        [BindNever]
        public Guid? Id { get; set; }
        public virtual CustomerViewModel? Customer { get; set; }
        public virtual CampaignViewModel? Campaign { get; set; }
        public DateTime? DateOfCreate { get; set; }
        public string FullName { get; set; }
        public string Message { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }
        public double? TotalPrice { get; set; }
        public int? Status { get; set; }
    }
}
