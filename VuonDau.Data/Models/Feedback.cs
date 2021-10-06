using System;
using System.Collections.Generic;

#nullable disable

namespace VuonDau.Data.Models
{
    public partial class Feedback
    {
        public int Id { get; set; }
        public int? OrderId { get; set; }
        public DateTime? DateOfCreate { get; set; }
        public string Description { get; set; }
        public int? Status { get; set; }

        public virtual Order Order { get; set; }
    }
}
