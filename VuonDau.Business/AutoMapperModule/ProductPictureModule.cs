using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;
using VuonDau.Business.Requests.ProductPicture;
using VuonDau.Business.ViewModel;
using VuonDau.Data.Models;

namespace VuonDau.Business.AutoMapperModule
{
    public static class ProductPictureModule
    {
        public static void ConfigProductPictureModule(this IMapperConfigurationExpression mc)
        {
            mc.CreateMap<ProductPicture, ProductPictureViewModel>().ReverseMap();
            mc.CreateMap<CreateProductPictureRequest, ProductPicture>();
            mc.CreateMap<UpdateProductPictureRequest, ProductPicture>();
        }
    }
}
