//using AutoMapper;
using AutoMapper;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using VuonDau.Business.AutoMapperModule;
//using VuonDau.Bussiness.AutoMapperModule;

namespace VuonDau.WebApi.App_Start
{
    public static class AutoMapperConfig
    {

        public static void ConfigureAutoMapper(this IServiceCollection services)
        {
            var mappingConfig = new MapperConfiguration(mc =>
            {
                mc.ConfigFarmerModule();
                mc.ConfigProductModule();
                mc.ConfigProductTypeModule();
                mc.ConfigProductPictureModule();
                mc.ConfigFarmModule();
                mc.ConfigFarmPictureModule();
                mc.ConfigFarmTypeModule();
                mc.ConfigHarvestModule();
                mc.ConfigHarvestSellingModule();
                mc.ConfigHarvestSellingPriceModule();
                mc.ConfigCustomerModule();
                mc.ConfigCustomerTypeModule();
                mc.ConfigCustomerGroupModule();
                mc.ConfigCustomerInGroupModule();
                mc.ConfigFeedbackModule();
                mc.ConfigOrderModule();
                mc.ConfigOrderDetailModule();
                mc.ConfigPaymentModule();
                mc.ConfigWalletModule();
                mc.ConfigTransactionModule();
                mc.ConfigAdminModule();
                mc.ConfigProductInCartModule();
            });
            IMapper mapper = mappingConfig.CreateMapper();
            services.AddSingleton(mapper);
        }
    }
}
