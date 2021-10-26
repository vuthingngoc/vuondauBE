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
using VuonDau.WebApi.App_Start;
using VuonDau.Data.Models;
using VuonDau.WebApi.Handlers;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Reflection;
//using VuonDau.Api.Config;
using FirebaseAdmin;
using Google.Apis.Auth.OAuth2;
using VuonDau.Api.Config;

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
            services.ConfigureSwagger();
            services.AddDbContext<VuondauDBContext>(opt => opt.UseSqlServer(Configuration.GetConnectionString("VuonDauDatabase"))
                .EnableSensitiveDataLogging()
                .UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking));
            services.ConfigMemoryCacheAndRedisCache(Configuration["Endpoint:RedisEndpoint"]);
            services.AddHttpClient();
            services.ConfigureAutoMapper();
            services.ConfigureDI();
            services.ConfigureServiceWorkers();
            services.ConfigDataProtection();
            using var json = Assembly.GetExecutingAssembly()
                .GetManifestResourceStream("VuonDau.WebApi.Firebase.firebase_config.json");
            var something = Assembly.GetExecutingAssembly().GetManifestResourceNames();
            FirebaseApp.Create(new AppOptions
            {
                Credential = GoogleCredential.FromStream(json)
            });
            services.AddRouting();
            AuthConfig.ConfigAuthentication(services, Configuration);
            //services.AddAuthentication("Bearer")
            //       .AddIdentityServerAuthentication(options =>
            //       {
            //           options.Authority = Configuration["IdentityServer:Domain"];
            //           options.RequireHttpsMetadata = false;
            //           options.ApiName = Configuration["IdentityServer:ApiName"];
            //       });
        }
        private string[] GetDomain()
        {
            var domains = Configuration.GetSection("Domain").Get<Dictionary<string, string>>()
            .SelectMany(s => s.Value.Split(",")).ToArray();
            return domains;
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, IApiVersionDescriptionProvider provider)
        {
            if (env.IsDevelopment() || env.IsProduction())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "VuonDau.WebApi v1"));
            }
            app.UseCors(MyAllowSpecificOrigins);
            app.UseForwardedHeaders(new ForwardedHeadersOptions
            {
                ForwardedHeaders = ForwardedHeaders.XForwardedFor | ForwardedHeaders.XForwardedProto
            });

            #region Multi lang
            var options = app.ApplicationServices.GetService<IOptions<RequestLocalizationOptions>>();
            app.UseRequestLocalization(options.Value);
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
            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
            app.ConfigureSwagger(provider);
        }
    }
}
