using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;
using VuonDau.Business.Requests.FarmType;
using VuonDau.Business.ViewModel;
using VuonDau.Data.Models;

namespace VuonDau.Business.AutoMapperModule
{
    public static class FarmTypeModule
    {
        public static void ConfigFarmTypeModule(this IMapperConfigurationExpression mc)
        {
            mc.CreateMap<FarmType, FarmTypeViewModel>().ReverseMap();
            mc.CreateMap<CreateFarmTypeRequest, FarmType>();
            mc.CreateMap<UpdateFarmTypeRequest, FarmType>();
        }
    }
}
