using System;
using System.Collections.Generic;
using System.Text;

namespace VuonDau.Business.Requests.Wallet
{
    public class UpdateWalletRequest
    {
        public Guid? CustomerId { get; set; }
        public double? Balance { get; set; }
    }
}
