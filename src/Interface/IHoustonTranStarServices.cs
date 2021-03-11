using System.Threading.Tasks;

namespace HoustonTranStar.Interface
{
    public interface IHoustonTranStarServices
    {
        Task UpdateCameras();

        Task UpdateIncidents();

        Task UpdateLaneClosures();

        Task UpdateRoadwaySegments();

        Task UpdateTravelTimes();
    }
}