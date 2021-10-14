using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;
using VuonDau.Business.Requests.Wallet;
using VuonDau.Business.ViewModel;
using VuonDau.Data.Models;

namespace VuonDau.Business.AutoMapperModule
{
    public static class WalletModule
    {
        public static void ConfigWalletModule(this IMapperConfigurationExpression mc)
        {
            mc.CreateMap<Wallet, WalletViewModel>().ReverseMap();
            mc.CreateMap<CreateWalletRequest, Wallet>();
            mc.CreateMap<UpdateWalletRequest, Wallet>();
        }
    }
}
