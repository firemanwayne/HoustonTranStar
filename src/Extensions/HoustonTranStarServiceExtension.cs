using HoustonTranStar.Concrete;
using HoustonTranStar.Hubs;
using HoustonTranStar.Interface;
using HoustonTranStar.Services;
using Microsoft.AspNetCore.SignalR;
using Microsoft.Extensions.Hosting;
using System;
using System.Net.Http;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class HoustonTranStarServiceExtension
    {
        public static void AddHoustonTranStarService(this IServiceCollection services, IHostEnvironment Env, Action<HoustonTranStarOptions> Options)
        {
            services.Configure(Options);
            services.AddTransient<HoustonTranStarHub>();

            services.AddScoped<IHoustonTranStarServices>(sp =>
            {
                var factory = sp.GetRequiredService<IHttpClientFactory>();
                var hubContext = sp.GetRequiredService<IHubContext<HoustonTranStarHub>>();

                return new HoustonTranStarServices(
                    Env,
                    factory,
                    hubContext);
            });

            services.AddHostedService<HoustonTranStarHostedService>();
        }
    }
}