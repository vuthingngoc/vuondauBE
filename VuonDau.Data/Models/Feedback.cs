using System;
using System.Collections.Generic;

#nullable disable

namespace VuonDau.Data.Models
{
    public partial class Feedback
    {
        public string Id { get; set; }
        public string OrderId { get; set; }
        public DateTime? DateOfCreate { get; set; }
        public string Description { get; set; }
        public bool? Status { get; set; }

        public virtual Order Order { get; set; }
    }
}
