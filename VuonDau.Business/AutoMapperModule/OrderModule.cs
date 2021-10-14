using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;
using VuonDau.Business.Requests.Order;
using VuonDau.Business.ViewModel;
using VuonDau.Data.Models;

namespace VuonDau.Business.AutoMapperModule
{
    public static class OrderModule
    {
        public static void ConfigOrderModule(this IMapperConfigurationExpression mc)
        {
            mc.CreateMap<Order, OrderViewModel>().ReverseMap();
            mc.CreateMap<CreateOrderRequest, Order>();
            mc.CreateMap<UpdateOrderRequest, Order>();
        }
    }
}
