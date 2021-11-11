using System;
using System.Collections.Generic;
using System.Text;

namespace VuonDau.Business.ViewModel
{
    public class TokenViewModel
    {
        public TokenViewModel(Guid id, string email, string fullName, int role, int status)
        {
            Id = id;
            Email = email;
            FullName = fullName;
            Role = role;
            Status = status;
        }
        public Guid Id { get; set; }
        public string Email { get; set; }
        public string FullName { get; set; }
        public int Role { get; set; }
        public int Status { get; set; }
    }
}
