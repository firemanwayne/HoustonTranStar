using HoustonTranStar.Concrete;
using HoustonTranStar.Hubs;
using HoustonTranStar.Interface;
using HoustonTranStar.Services;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;

namespace HoustonTranStar.Extensions
{
    public static class HoustonTranStarServiceExtension
    {
        public static void AddHoustonTranStarService(this IServiceCollection services, Action<HoustonTranStarOptions> Options)
        {
            services.Configure(Options);            

            services.AddTransient<HoustonTranStarHub>();
            services.AddScoped<IHoustonTranStarServices, HoustonTranStarServices>();
            services.AddSingleton<IHostedService, HoustonTranStarHostedService>();
        }
    }
}