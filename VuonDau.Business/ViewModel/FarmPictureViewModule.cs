using System;
using System.Collections.Generic;
using System.Text;
using VuonDau.Data.Models;

namespace VuonDau.Business.ViewModel
{
    public class FarmPictureViewModel
    {
        public Guid Id { get; set; }
        public virtual FarmViewModel Farm { get; set; }
        public string Src { get; set; }
        public string Alt { get; set; }
    }
}
