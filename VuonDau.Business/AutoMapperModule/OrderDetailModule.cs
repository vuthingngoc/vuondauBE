using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;
using VuonDau.Business.Requests.OrderDetail;
using VuonDau.Business.ViewModel;
using VuonDau.Data.Models;

namespace VuonDau.Business.AutoMapperModule
{
    public static class OrderDetailModule
    {
        public static void ConfigOrderDetailModule(this IMapperConfigurationExpression mc)
        {
            mc.CreateMap<OrderDetail, OrderDetailViewModel>().ReverseMap();
            mc.CreateMap<CreateOrderDetailRequest, OrderDetail>();
            mc.CreateMap<UpdateOrderDetailRequest, OrderDetail>();
        }
    }
}
