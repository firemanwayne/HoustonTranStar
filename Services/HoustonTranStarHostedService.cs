using HoustonTranStar.Concrete;
using HoustonTranStar.Interface;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace HoustonTranStar.Services
{
    public class HoustonTranStarHostedService : BackgroundService
    {
        readonly HoustonTranStarOptions Options;
        readonly IServiceProvider Services;
        readonly ILogger<HoustonTranStarHostedService> Logger;

        public HoustonTranStarHostedService(
            IServiceProvider Services,
            IOptions<HoustonTranStarOptions> Options,
            ILogger<HoustonTranStarHostedService> Logger)
        {
            this.Logger = Logger;
            this.Services = Services;
            this.Options = Options.Value;
        }

        protected async override Task ExecuteAsync(CancellationToken StoppingToken)
        {
            try
            {
                using var Scope = Services.CreateScope();
                while (true)
                {
                    var houstonTranStarService = Scope.ServiceProvider.GetRequiredService<IHoustonTranStarServices>();
                    //await GetRoadWaySegmentDataXml();
                    //await GetSpeedTravelTimeDataXml();

                    if (Options.IncidentUpdates)
                        await houstonTranStarService.UpdateIncidents();

                    if (Options.LaneClosures)
                        await houstonTranStarService.UpdateLaneClosures();

                    //await GetCameraListData();
                    await Task.Delay(5000, StoppingToken);
                }
            }
            catch (Exception ex)
            {
                Logger.Log(LogLevel.Critical, ex.Message);
                throw new Exception(ex.Message);
            }
        }
    }
}