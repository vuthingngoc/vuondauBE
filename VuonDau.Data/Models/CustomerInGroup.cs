using System;
using System.Collections.Generic;

#nullable disable

namespace VuonDau.Data.Models
{
    public partial class CustomerInGroup
    {
        public Guid CustomerId { get; set; }
        public Guid CustomerGroupId { get; set; }
        public DateTime? JoinDate { get; set; }

        public virtual Customer Customer { get; set; }
        public virtual CustomerGroup CustomerGroup { get; set; }
    }
}
