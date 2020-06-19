using System;
using System.Collections.Generic;
using System.Text;
using BitcoGG_API.Composition.Installer.Interfaces;
using BitcoGG_API.Services;
using BitcoGG_API.Services.Interfaces;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace BitcoGG_API.Composition.Installer
{
    public class ServiceInstaller : IInstaller
    {
        public void InstallServices(IServiceCollection services, IConfiguration configuration)
        {
            //installing all the services in the api
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<ICoinService, CoinService>();
            services.AddScoped<IFileService, FileService>();
        }
    }
}
