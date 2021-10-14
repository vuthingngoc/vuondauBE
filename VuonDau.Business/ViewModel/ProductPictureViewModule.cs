using System;
using System.Collections.Generic;
using System.Text;

namespace VuonDau.Business.ViewModel
{
    public class ProductPictureViewModel
    {
        public Guid Id { get; set; }
        public Guid? ProductId { get; set; }
        public string Src { get; set; }
        public string Alt { get; set; }
    }
}
