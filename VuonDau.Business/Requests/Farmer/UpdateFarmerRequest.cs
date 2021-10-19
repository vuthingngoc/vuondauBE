using System;
using System.Collections.Generic;
using System.Text;

namespace VuonDau.Business.Requests.Farmer
{
    public class UpdateFarmerRequest
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Password { get; set; }
        public string Phone { get; set; }
        public DateTime? BirthDay { get; set; }
        public DateTime? DateUpdate { get; set; }
        public int? Gender { get; set; }
        public int? Status { get; set; }
    }
}
