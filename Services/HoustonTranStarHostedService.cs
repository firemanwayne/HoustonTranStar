using HoustonTranStar.Abstract;
using HoustonTranStar.Concrete;
using HoustonTranStar.Interface;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace HoustonTranStar.Services
{
    public class HoustonTranStarHostedService : HostedService
    {
        private readonly HoustonTranStarOptions Options;
        private readonly IServiceProvider Services;
        private readonly ILogger<HoustonTranStarHostedService> Logger;
        private IHoustonTranStarServices HoustonTranStarService;

        public HoustonTranStarHostedService(
            IOptions<HoustonTranStarOptions> Options,
            IServiceProvider Services,
            ILogger<HoustonTranStarHostedService> Logger)
        {
            this.Options = Options.Value;
            this.Logger = Logger;
            this.Services = Services;
        }

        public async override Task ExecuteAsync(CancellationToken StoppingToken)
        {
            try
            {
                using (var Scope = Services.CreateScope())
                    while (true)
                    {
                        HoustonTranStarService = Scope.ServiceProvider.GetRequiredService<IHoustonTranStarServices>();
                        //await GetRoadWaySegmentDataXml();
                        //await GetSpeedTravelTimeDataXml();

                        if (Options.IncidentUpdates)
                            await HoustonTranStarService.UpdateIncidents();

                        if (Options.LaneClosures)
                            await HoustonTranStarService.UpdateLaneClosures();

                        //await GetCameraListData();
                        Thread.Sleep(60000);
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