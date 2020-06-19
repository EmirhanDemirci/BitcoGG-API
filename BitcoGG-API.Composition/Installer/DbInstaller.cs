using System;
using System.Collections.Generic;
using System.Text;
using BitcoGG_API.Composition.Installer.Interfaces;
using BitcoGG_API.DataAccess.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace BitcoGG_API.Composition.Installer
{
    public class DbInstaller : IInstaller
    {
        public void InstallServices(IServiceCollection services, IConfiguration configuration)
        {
            var connectionString = "Server=tcp:bitcogg.database.windows.net,1433;Initial Catalog=BitcoGG;Persist Security Info=False;User ID=emirhan75;Password=Kilever2000!;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";
            services.AddTransient<ApplicationDbContext>()
                .AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(
                    connectionString ?? throw new InvalidOperationException()));
        }
    }
}
