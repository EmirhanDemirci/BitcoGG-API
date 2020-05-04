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
            //TODO: Change hardcoded Connectionstring
            var connectionString = "Server=.;Database=BitcoGG;Trusted_Connection=True;MultipleActiveResultSets=true";
            services.AddTransient<ApplicationDbContext>()
                .AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(
                    connectionString ?? throw new InvalidOperationException()));
        }
    }
}
