using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;
using VuonDau.Business.Requests.ProductInCart;
using VuonDau.Business.ViewModel;
using VuonDau.Data.Models;

namespace VuonDau.Business.AutoMapperModule
{
    public static class ProductInCartModule
    {
        public static void ConfigProductInCartModule(this IMapperConfigurationExpression mc)
        {
            mc.CreateMap<ProductInCart, ProductInCartViewModel>().ReverseMap();
            mc.CreateMap<CreateProductInCartRequest, ProductInCart>();
            mc.CreateMap<UpdateProductInCartRequest, ProductInCart>();
        }
    }
}
