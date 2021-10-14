using System;
using System.Collections.Generic;
using System.Text;

namespace VuonDau.Business.Requests.FarmPicture
{
    public class UpdateFarmPictureRequest
    {
        public Guid? FarmId { get; set; }
        public string Src { get; set; }
        public string Alt { get; set; }
    }
}
