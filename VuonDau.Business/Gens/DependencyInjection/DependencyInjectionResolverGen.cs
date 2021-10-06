
/////////////////////////////////////////////////////////////////
//
//              AUTO-GENERATED
//
/////////////////////////////////////////////////////////////////

using VuonDau.Data.Models;
using Microsoft.Extensions.DependencyInjection;
using VuonDau.Business.Gens.Services;
using VuonDau.Data.Repositories;
using Microsoft.EntityFrameworkCore;
using Reso.Core.BaseConnect;
namespace VuonDau.Data.Gens.Commons
{
    public static class DependencyInjectionResolverGen
    {
        public static void InitializerDI(this IServiceCollection services)
        {
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<DbContext, VuondauDBContext>();
        
            services.AddScoped<ICustomerService, CustomerService>();
            services.AddScoped<ICustomerRepository, CustomerRepository>();
        
            services.AddScoped<ICustomerGroupService, CustomerGroupService>();
            services.AddScoped<ICustomerGroupRepository, CustomerGroupRepository>();
        
            services.AddScoped<ICustomerInGroupService, CustomerInGroupService>();
            services.AddScoped<ICustomerInGroupRepository, CustomerInGroupRepository>();
        
            services.AddScoped<ICustomerTypeService, CustomerTypeService>();
            services.AddScoped<ICustomerTypeRepository, CustomerTypeRepository>();
        
            services.AddScoped<IFarmService, FarmService>();
            services.AddScoped<IFarmRepository, FarmRepository>();
        
            services.AddScoped<IFarmerService, FarmerService>();
            services.AddScoped<IFarmerRepository, FarmerRepository>();
        
            services.AddScoped<IFarmPictureService, FarmPictureService>();
            services.AddScoped<IFarmPictureRepository, FarmPictureRepository>();
        
            services.AddScoped<IFarmTypeService, FarmTypeService>();
            services.AddScoped<IFarmTypeRepository, FarmTypeRepository>();
        
            services.AddScoped<IFeedbackService, FeedbackService>();
            services.AddScoped<IFeedbackRepository, FeedbackRepository>();
        
            services.AddScoped<IHarvestService, HarvestService>();
            services.AddScoped<IHarvestRepository, HarvestRepository>();
        
            services.AddScoped<IHarvestSellingService, HarvestSellingService>();
            services.AddScoped<IHarvestSellingRepository, HarvestSellingRepository>();
        
            services.AddScoped<IHarvestSellingPriceService, HarvestSellingPriceService>();
            services.AddScoped<IHarvestSellingPriceRepository, HarvestSellingPriceRepository>();
        
            services.AddScoped<IOrderService, OrderService>();
            services.AddScoped<IOrderRepository, OrderRepository>();
        
            services.AddScoped<IOrderDetailService, OrderDetailService>();
            services.AddScoped<IOrderDetailRepository, OrderDetailRepository>();
        
            services.AddScoped<IPaymentService, PaymentService>();
            services.AddScoped<IPaymentRepository, PaymentRepository>();
        
            services.AddScoped<IProductService, ProductService>();
            services.AddScoped<IProductRepository, ProductRepository>();
        
            services.AddScoped<IProductPictureService, ProductPictureService>();
            services.AddScoped<IProductPictureRepository, ProductPictureRepository>();
        
            services.AddScoped<IProductTypeService, ProductTypeService>();
            services.AddScoped<IProductTypeRepository, ProductTypeRepository>();
        
            services.AddScoped<ITransactionService, TransactionService>();
            services.AddScoped<ITransactionRepository, TransactionRepository>();
        
            services.AddScoped<IWalletService, WalletService>();
            services.AddScoped<IWalletRepository, WalletRepository>();
        }
    }
}
