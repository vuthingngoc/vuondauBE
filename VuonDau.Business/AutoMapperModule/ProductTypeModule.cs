using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;
using VuonDau.Business.Requests.ProductType;
using VuonDau.Business.ViewModel;
using VuonDau.Data.Models;

namespace VuonDau.Business.AutoMapperModule
{
    public static class ProductTypeModule
    {
        public static void ConfigProductTypeModule(this IMapperConfigurationExpression mc)
        {
            mc.CreateMap<ProductType, ProductTypeViewModel>().ReverseMap();
            mc.CreateMap<CreateProductTypeRequest, ProductType>();
            mc.CreateMap<UpdateProductTypeRequest, ProductType>();
        }
    }
}
