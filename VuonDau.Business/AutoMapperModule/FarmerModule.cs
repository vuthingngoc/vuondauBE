using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;
using VuonDau.Business.Requests.Farmer;
using VuonDau.Business.ViewModel;
using VuonDau.Data.Models;

namespace VuonDau.Business.AutoMapperModule
{
    public static class FarmerModule
    {
        public static void ConfigFarmerModule(this IMapperConfigurationExpression mc)
        {
            mc.CreateMap<Farmer, FarmerViewModel>().ReverseMap();
            mc.CreateMap<CreateFarmerRequest, Farmer>();
            mc.CreateMap<UpdateFarmerRequest, Farmer>();
        }
    }
}
