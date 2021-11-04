using System;
using System.Collections.Generic;

#nullable disable

namespace VuonDau.Data.Models
{
    public partial class Feedback
    {
        public Guid Id { get; set; }
        public Guid? OrderId { get; set; }
        public Guid? HarvestId { get; set; }
        public DateTime? DateOfCreate { get; set; }
        public string Description { get; set; }
        public int? Status { get; set; }

        public virtual Harvest Harvest { get; set; }
        public virtual Order Order { get; set; }
    }
}
