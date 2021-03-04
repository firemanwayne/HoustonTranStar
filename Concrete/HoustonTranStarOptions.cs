namespace HoustonTranStar.Concrete
{
    public class HoustonTranStarOptions
    {
        public HoustonTranStarOptions()
        { }

        public bool IncidentUpdates { get; private set; }
        public bool LaneClosures { get; private set; }
        public bool SpeedTravelTimes { get; private set; }

        public void AddIncidentUpdate() => IncidentUpdates = true;
        public void AddLaneClosures() => LaneClosures = true;
        public void AddSpeedTravelTimes() => SpeedTravelTimes = true;
    }
}