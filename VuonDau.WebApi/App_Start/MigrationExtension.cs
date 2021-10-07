using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VuonDau.WebApi.App_Start
{
    public static class MigrationExtension
    {
        public static void ConfigMigration<TDbContext>(this IApplicationBuilder app) where TDbContext : DbContext
        {
            try
            {
                using var serviceScope = app.ApplicationServices.GetRequiredService<IServiceScopeFactory>()
                    .CreateScope();
                serviceScope.ServiceProvider.GetService<TDbContext>().Database.Migrate();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"{DateTime.UtcNow.AddHours(7).ToString("yyyy-MM-dd HH:mm:ss.fff")}||fail: VuonDau.WebApi.App_Start.MigrationExtension[0]\n{ex.ToString()}");
            }
        }
    }
}
