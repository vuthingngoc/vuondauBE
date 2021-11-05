using System;
using System.Collections.Generic;
using System.Text;

namespace VuonDau.Business.Requests.HarvestPicture
{
    public class CreateHarvestPictureRequest
    {
        public Guid? HarvestId { get; set; }
        public string Src { get; set; }
        public string Alt { get; set; }

    }
}
