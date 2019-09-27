using HoustonTranStar.Interface;
using Microsoft.AspNetCore.SignalR;
using System.Threading.Tasks;

namespace HoustonTranStar.Hubs
{
    public class HoustonTranStarHub : Hub
    {
        private readonly IHoustonTranStarServices Service;

        public HoustonTranStarHub(IHoustonTranStarServices Service)
        {
            this.Service = Service;
        }

        public async override Task OnConnectedAsync()
        {
            await Service.UpdateIncidents();
            await Service.UpdateLaneClosures();

            await base.OnConnectedAsync();
        }
    }
}