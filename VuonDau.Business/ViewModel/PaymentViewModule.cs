using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;
using System.Collections.Generic;
using System.Text;
using VuonDau.Data.Models;

namespace VuonDau.Business.ViewModel
{
    public class PaymentViewModel
    {
        [BindNever]
        public Guid? Id { get; set; }
        public string Method { get; set; }
    }
}
