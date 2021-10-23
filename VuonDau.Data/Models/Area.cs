using System;
using System.Collections.Generic;

#nullable disable

namespace VuonDau.Data.Models
{
    public partial class Area
    {
        public Area()
        {
            Farms = new HashSet<Farm>();
        }

        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public virtual ICollection<Farm> Farms { get; set; }
    }
}
