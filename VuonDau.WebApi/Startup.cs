using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpOverrides;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ApiExplorer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Microsoft.OpenApi.Models;
using Reso.Core.Extension;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using UniPro.WebApi.App_Start;
using VuonDau.Data.Models;
using VuonDau.WebApi.Handlers;

namespace VuonDau.WebApi
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public static readonly string MyAllowSpecificOrigins = "_myAllowSpecificOrigins";

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {

            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "VuonDau.WebApi", Version = "v1" });
            });
            services.AddCors(options =>
            {

                options.AddPolicy(MyAllowSpecificOrigins,
                builder =>
                {
                    builder
                    .WithOrigins(GetDomain())
                    .AllowAnyHeader()
                    .AllowAnyMethod();
                });
            });
            services.ConfigureFilter<ErrorHandlingFilter>();
            services.JsonFormatConfig();
            //services.ConfigureSwagger();
            services.AddDbContext<VuondauDBContext>(opt => opt.UseSqlServer(Configuration.GetConnectionString("VuonDauDatabase"))
                .EnableSensitiveDataLogging()
                .UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking));
            services.ConfigMemoryCacheAndRedisCache(Configuration["Endpoint:RedisEndpoint"]);
            services.AddHttpClient();
            services.ConfigureAutoMapper();
            services.ConfigureDI();
            services.ConfigureServiceWorkers();
            services.ConfigDataProtection();
        }
        private string[] GetDomain()
        {
            var domains = Configuration.GetSection("Domain").Get<Dictionary<string, string>>()
            .SelectMany(s => s.Value.Split(",")).ToArray();
            return domains;
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env/*, IApiVersionDescriptionProvider provider*/)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "VuonDau.WebApi v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
            app.UseCors(MyAllowSpecificOrigins);
            app.UseForwardedHeaders(new ForwardedHeadersOptions
            {
                ForwardedHeaders = ForwardedHeaders.XForwardedFor | ForwardedHeaders.XForwardedProto
            });
            var options = app.ApplicationServices.GetService<IOptions<RequestLocalizationOptions>>();
            app.UseRequestLocalization(options.Value);
            #region Multi lang
            app.Use((context, next) =>
            {
                var userLangs = context.Request.Headers["accept-language"].ToString();
                var lang = userLangs.Split(',').FirstOrDefault();
                if (string.IsNullOrEmpty(lang))
                {
                    lang = "vi";
                }
                Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo(lang);
                Thread.CurrentThread.CurrentUICulture = Thread.CurrentThread.CurrentCulture;
                context.Items["SelectedLng"] = lang;
                context.Items["ClientCulture"] = Thread.CurrentThread.CurrentUICulture.Name;
                return next();
            });
            #endregion
            app.ConfigMigration<VuondauDBContext>();
            app.ConfigureErrorHandler(env);
            app.UseRouting();

            app.ConfigureAuthor();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
            //app.ConfigureSwagger(provider);
        }
    }
}
