using EaAppFramework.Config;
using EaAppFramework.Driver;
using EaApplicationTest.Interfaces;
using EaApplicationTest.Pages;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EaApplicationTest
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddSingleton(ConfigReader.ReadConfig());
            services.AddScoped<IPlaywrightDriver, PlaywrightDriver>();
            services.AddScoped<IPlaywrightDriverInitializer, PlaywrightDriverInitializer>();
            services.AddScoped<IHomePage, HomePage>();
            services.AddScoped<IProductPage, ProductPage>();
            services.AddScoped<IProductListPage, ProductListPage>();

        }
    }
}
