using System;
using System.Collections.Generic;
using System.Text;
using VuonDau.Data.Models;

namespace VuonDau.Business.ViewModel
{
    public class FeedbackViewModel
    {
        public Guid Id { get; set; }
        public virtual OrderViewModel Order { get; set; }
        public DateTime? DateOfCreate { get; set; }
        public string Description { get; set; }
        public int? Status { get; set; }
    }
}
