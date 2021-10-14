using System;
using System.Collections.Generic;
using System.Text;

namespace VuonDau.Business.ViewModel
{
    public class FarmPictureViewModel
    {
        public Guid Id { get; set; }
        public Guid? FarmId { get; set; }
        public string Src { get; set; }
        public string Alt { get; set; }
    }
}
