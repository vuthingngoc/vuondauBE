using System;
using System.Collections.Generic;
using System.Text;

namespace VuonDau.Business.Requests.Wallet
{
    public class CreateWalletRequest
    {
        public Guid? CustomerId { get; set; }
        public double? Balance { get; set; }
    }
}
