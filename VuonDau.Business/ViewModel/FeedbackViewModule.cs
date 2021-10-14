using System;
using System.Collections.Generic;
using System.Text;

namespace VuonDau.Business.ViewModel
{
    public class FeedbackViewModel
    {
        public Guid Id { get; set; }
        public Guid? OrderId { get; set; }
        public DateTime? DateOfCreate { get; set; }
        public string Description { get; set; }
        public int? Status { get; set; }
    }
}
