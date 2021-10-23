using System;
using System.Collections.Generic;
using System.Text;
using VuonDau.Data.Models;

namespace VuonDau.Business.ViewModel
{
    public class WalletViewModel
    {
        public Guid Id { get; set; }
        public virtual CustomerViewModel Customer { get; set; }
        public double? Balance { get; set; }
    }
}
