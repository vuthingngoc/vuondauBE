using System;
using System.Collections.Generic;
using System.Text;
using VuonDau.Data.Models;

namespace VuonDau.Business.ViewModel
{
    public class CustomerFullViewModel
    {
        public Guid Id { get; set; }
        public virtual CustomerType CustomerTypeNavigation { get; set; }
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Password { get; set; }
        public string Phone { get; set; }
        public DateTime? BirthDay { get; set; }
        public int? Gender { get; set; }
        public DateTime? DateOfCreate { get; set; }
        public int? Status { get; set; }

    }
}
