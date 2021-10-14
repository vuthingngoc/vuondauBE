using System;
using System.Collections.Generic;
using System.Text;

namespace VuonDau.Business.ViewModel
{
    public class WalletViewModel
    {
        public Guid Id { get; set; }
        public Guid? CustomerId { get; set; }
        public double? Balance { get; set; }
    }
}
