using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;
using System.Collections.Generic;
using System.Text;
using VuonDau.Data.Models;

namespace VuonDau.Business.ViewModel
{
    public class WalletViewModel
    {
        [BindNever]
        public Guid? Id { get; set; }
        public virtual CustomerViewModel? Customer { get; set; }
        public double? Balance { get; set; }
    }
}
