using System;

namespace HoustonTranStar.Concrete
{
    public static class HoustonTranStarUriManager
    {
        static string HoustonTranStarBaseAddress => "http://traffic.houstontranstar.org/datafeed/getdatafeed.aspx?type=";
        static string LiveCameraListDataFeedAddress => "http://traffic.houstontranstar.org/datafeed/getdatafeed.aspx?type=cctv";

        static string LiveSpeedDataFeedAddressXml { get => $"{HoustonTranStarBaseAddress}speeds&fmt=xml"; }
        static string LiveTravelTimeDataFeedAddressXml { get => $"{HoustonTranStarBaseAddress}speed_segments&fmt=xml"; }
        static string LiveIncidentDataFeedAddressXml { get => $"{HoustonTranStarBaseAddress}inc&fmt=xml"; }
        static string LiveLaneClosureDataFeedAddressXml { get => $"{HoustonTranStarBaseAddress}laneclosures&fmt=xml"; }

        static string LiveSpeedDataFeedAddressJson { get => $"{HoustonTranStarBaseAddress}speeds&fml=json"; }
        static string LiveTravelTimeDataFeedAddressJson { get => $"{HoustonTranStarBaseAddress}speed_segments&fml=json"; }
        static string LiveIncidentDataFeedAddressJson { get => $"{HoustonTranStarBaseAddress}inc&fml=json"; }
        static string LiveLaneClosureDataFeedAddressJson { get => $"{HoustonTranStarBaseAddress}laneclosures&fml=json"; }

        public static Uri GetHoustonTranStarBaseAddress() => new(HoustonTranStarBaseAddress);
        public static Uri GetLiveCameraListDataFeedAddress() => new(LiveCameraListDataFeedAddress);
        public static Uri GetLiveSpeedDataFeedAddressXml() => new(LiveSpeedDataFeedAddressXml);
        public static Uri GetLiveTravelTimeDataFeedAddressXml() => new(LiveTravelTimeDataFeedAddressXml);
        public static Uri GetLiveIncidentDataFeedAddressXml() => new(LiveIncidentDataFeedAddressXml);
        public static Uri GetLiveLaneClosureDataFeedAddressXml() => new(LiveLaneClosureDataFeedAddressXml);
        public static Uri GetLiveSpeedDataFeedAddressJson() => new(LiveSpeedDataFeedAddressJson);
        public static Uri GetLiveTravelTimeDataFeedAddressJson() => new(LiveTravelTimeDataFeedAddressJson);
        public static Uri GetLiveIncidentDataFeedAddressJson() => new(LiveIncidentDataFeedAddressJson);
        public static Uri GetLiveLaneClosureDataFeedAddressJson() => new(LiveLaneClosureDataFeedAddressJson);
    }
}