using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;
using VuonDau.Business.Requests.Harvest;
using VuonDau.Business.ViewModel;
using VuonDau.Data.Models;

namespace VuonDau.Business.AutoMapperModule
{
    public static class HarvestModule
    {
        public static void ConfigHarvestModule(this IMapperConfigurationExpression mc)
        {
            mc.CreateMap<Harvest, HarvestViewModel>().ReverseMap();
            mc.CreateMap<CreateHarvestRequest, Harvest>();
            mc.CreateMap<UpdateHarvestRequest, Harvest>();
        }
    }
}
