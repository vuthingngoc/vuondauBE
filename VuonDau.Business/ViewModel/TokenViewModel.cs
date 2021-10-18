using System;
using System.Collections.Generic;
using System.Text;

namespace VuonDau.Business.ViewModel
{
    public class TokenViewModel
    {
        public TokenViewModel(Guid id, int role)
        {
            Id = id;
            Role = role;
        }
        public Guid Id { get; set; }
        public int Role { get; set; }
    }
}
