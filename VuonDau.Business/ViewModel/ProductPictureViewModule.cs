using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;
using System.Collections.Generic;
using System.Text;
using VuonDau.Data.Models;

namespace VuonDau.Business.ViewModel
{
    public class ProductPictureViewModel
    {
        [BindNever]
        public Guid? Id { get; set; }
        public virtual ProductViewModel? Product { get; set; }
        public string Src { get; set; }
        public string Alt { get; set; }
    }
}
