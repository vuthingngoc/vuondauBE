﻿using System;
using System.Collections.Generic;
using System.Text;

namespace VuonDau.Business.Requests.ProductPicture
{
    public class CreateProductPictureRequest
    {
        public Guid? ProductId { get; set; }
        public string Src { get; set; }
        public string Alt { get; set; }

    }
}
