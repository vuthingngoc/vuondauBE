using System;
using System.Collections.Generic;
using System.Text;
using VuonDau.Data.Models;

namespace VuonDau.Business.ViewModel
{
    public class PaymentViewModel
    {
        public Guid Id { get; set; }
        public string Method { get; set; }
    }
}
