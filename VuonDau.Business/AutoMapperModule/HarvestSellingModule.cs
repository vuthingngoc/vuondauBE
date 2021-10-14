using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;
using VuonDau.Business.Requests.HarvestSelling;
using VuonDau.Business.ViewModel;
using VuonDau.Data.Models;

namespace VuonDau.Business.AutoMapperModule
{
    public static class HarvestSellingModule
    {
        public static void ConfigHarvestSellingModule(this IMapperConfigurationExpression mc)
        {
            mc.CreateMap<HarvestSelling, HarvestSellingViewModel>().ReverseMap();
            mc.CreateMap<CreateHarvestSellingRequest, HarvestSelling>();
            mc.CreateMap<UpdateHarvestSellingRequest, HarvestSelling>();
        }
    }
}
