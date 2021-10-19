using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;
using VuonDau.Business.Requests.Product;
using VuonDau.Business.ViewModel;
using VuonDau.Data.Models;

namespace VuonDau.Business.AutoMapperModule
{
    public static class ProductModule
    {
        public static void ConfigProductModule(this IMapperConfigurationExpression mc)
        {
            mc.CreateMap<Product, ProductFullViewModel>().ReverseMap();
            mc.CreateMap<CreateProductRequest, Product>();
            mc.CreateMap<UpdateProductRequest, Product>();
        }
    }
}
