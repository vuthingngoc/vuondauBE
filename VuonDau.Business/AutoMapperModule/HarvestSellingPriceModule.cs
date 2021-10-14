using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;
using VuonDau.Business.Requests.HarvestSellingPrice;
using VuonDau.Business.ViewModel;
using VuonDau.Data.Models;

namespace VuonDau.Business.AutoMapperModule
{
    public static class HarvestSellingPriceModule
    {
        public static void ConfigHarvestSellingPriceModule(this IMapperConfigurationExpression mc)
        {
            mc.CreateMap<HarvestSellingPrice, HarvestSellingPriceViewModel>().ReverseMap();
            mc.CreateMap<CreateHarvestSellingPriceRequest, HarvestSellingPrice>();
            mc.CreateMap<UpdateHarvestSellingPriceRequest, HarvestSellingPrice>();
        }
    }
}
