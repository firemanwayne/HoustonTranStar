using System;

namespace HoustonTranStar.Concrete
{
    public static class HoustonTranStarUriManager
    {
        private static string HoustonTranStarBaseAddress { get => "http://traffic.houstontranstar.org/datafeed/getdatafeed.aspx?type="; }
        private static string LiveCameraListDataFeedAddress { get => "http://traffic.houstontranstar.org/datafeed/getdatafeed.aspx?type=cctv"; }

        private static string LiveSpeedDataFeedAddressXml { get => $"{HoustonTranStarBaseAddress}speeds&fmt=xml"; }
        private static string LiveTravelTimeDataFeedAddressXml { get => $"{HoustonTranStarBaseAddress}speed_segments&fmt=xml"; }
        private static string LiveIncidentDataFeedAddressXml { get => $"{HoustonTranStarBaseAddress}inc&fmt=xml"; }
        private static string LiveLaneClosureDataFeedAddressXml { get => $"{HoustonTranStarBaseAddress}laneclosures&fmt=xml"; }

        private static string LiveSpeedDataFeedAddressJson { get => $"{HoustonTranStarBaseAddress}speeds&fml=json"; }
        private static string LiveTravelTimeDataFeedAddressJson { get => $"{HoustonTranStarBaseAddress}speed_segments&fml=json"; }
        private static string LiveIncidentDataFeedAddressJson { get => $"{HoustonTranStarBaseAddress}inc&fml=json"; }
        private static string LiveLaneClosureDataFeedAddressJson { get => $"{HoustonTranStarBaseAddress}laneclosures&fml=json"; }

        public static Uri GetHoustonTranStarBaseAddress() => new Uri(HoustonTranStarBaseAddress);

        public static Uri GetLiveCameraListDataFeedAddress() => new Uri(LiveCameraListDataFeedAddress);

        public static Uri GetLiveSpeedDataFeedAddressXml() => new Uri(LiveSpeedDataFeedAddressXml);

        public static Uri GetLiveTravelTimeDataFeedAddressXml() => new Uri(LiveTravelTimeDataFeedAddressXml);

        public static Uri GetLiveIncidentDataFeedAddressXml() => new Uri(LiveIncidentDataFeedAddressXml);

        public static Uri GetLiveLaneClosureDataFeedAddressXml() => new Uri(LiveLaneClosureDataFeedAddressXml);

        public static Uri GetLiveSpeedDataFeedAddressJson() => new Uri(LiveSpeedDataFeedAddressJson);

        public static Uri GetLiveTravelTimeDataFeedAddressJson() => new Uri(LiveTravelTimeDataFeedAddressJson);

        public static Uri GetLiveIncidentDataFeedAddressJson() => new Uri(LiveIncidentDataFeedAddressJson);

        public static Uri GetLiveLaneClosureDataFeedAddressJson() => new Uri(LiveLaneClosureDataFeedAddressJson);
    }
}