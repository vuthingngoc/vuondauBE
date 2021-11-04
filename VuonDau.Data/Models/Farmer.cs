using System;
using System.Collections.Generic;

#nullable disable

namespace VuonDau.Data.Models
{
    public partial class Farmer
    {
        public Farmer()
        {
            Farms = new HashSet<Farm>();
        }

        public Guid Id { get; set; }
        public string Email { get; set; }
        public string FullName { get; set; }
        public string Password { get; set; }
        public string Phone { get; set; }
        public DateTime? BirthDay { get; set; }
        public int? Gender { get; set; }
        public DateTime? DateOfCreate { get; set; }
        public int? Status { get; set; }

        public virtual ICollection<Farm> Farms { get; set; }
    }
}
