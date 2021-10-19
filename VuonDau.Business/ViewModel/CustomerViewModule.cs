using System;
using System.Collections.Generic;
using System.Text;

namespace VuonDau.Business.ViewModel
{
    public class CustomerViewModel
    {
        public Guid Id { get; set; }
        public Guid? CustomerType { get; set; }
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Password { get; set; }
        public string Phone { get; set; }
        public DateTime? BirthDay { get; set; }
        public int? Gender { get; set; }
        public DateTime? DateOfCreate { get; set; }
        public int? Status { get; set; }

        public static implicit operator CustomerViewModel(CustomerFullViewModel v)
        {
            throw new NotImplementedException();
        }
    }
}
