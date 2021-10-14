using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;
using VuonDau.Business.Requests.Payment;
using VuonDau.Business.ViewModel;
using VuonDau.Data.Models;

namespace VuonDau.Business.AutoMapperModule
{
    public static class PaymentModule
    {
        public static void ConfigPaymentModule(this IMapperConfigurationExpression mc)
        {
            mc.CreateMap<Payment, PaymentViewModel>().ReverseMap();
            mc.CreateMap<CreatePaymentRequest, Payment>();
            mc.CreateMap<UpdatePaymentRequest, Payment>();
        }
    }
}
