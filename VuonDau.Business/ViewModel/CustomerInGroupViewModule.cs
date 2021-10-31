using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;
using System.Collections.Generic;
using System.Text;
using VuonDau.Data.Models;

namespace VuonDau.Business.ViewModel
{
    public class CustomerInGroupViewModel
    {
        [BindNever]
        public virtual CustomerViewModel? Customer { get; set; }
        public virtual CustomerGroupViewModel? CustomerGroup { get; set; }
        public DateTime? JoinDate { get; set; }
    }
}
