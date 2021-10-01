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

        public string Id { get; set; }
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Password { get; set; }
        public string Phone { get; set; }
        public DateTime? BirthDay { get; set; }
        public bool? Gender { get; set; }
        public DateTime? DateOfCreate { get; set; }
        public bool? Status { get; set; }

        public virtual ICollection<Farm> Farms { get; set; }
    }
}
