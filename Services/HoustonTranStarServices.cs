using HoustonTranStar.Concrete;
using HoustonTranStar.Entities.Incidents;
using HoustonTranStar.Entities.LaneClosures;
using HoustonTranStar.Hubs;
using HoustonTranStar.Interface;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;

namespace HoustonTranStar.Services
{
    public class HoustonTranStarServices : IHoustonTranStarServices
    {
        private readonly IWebHostEnvironment Env;
        private readonly IHttpClientFactory ClientFactory;
        private readonly IHubContext<HoustonTranStarHub> HoustonTranStarHub;

        public HoustonTranStarServices(
            IWebHostEnvironment Env,
            IHttpClientFactory ClientFactory,            
            IHubContext<HoustonTranStarHub> HoustonTranStarHub)
        {
            this.Env = Env;
            this.ClientFactory = ClientFactory;            
            this.HoustonTranStarHub = HoustonTranStarHub;
        }

        public async Task UpdateCameras() => await GetCameraListData();

        public async Task UpdateIncidents() => await GetIncidentDataXml();

        public async Task UpdateLaneClosures() => await GetLaneClosureDataXml();

        public async Task UpdateRoadwaySegments() => await GetRoadWaySegmentDataXml();

        public async Task UpdateTravelTimes() => await GetSpeedTravelTimeDataXml();

        private async Task GetRoadWaySegmentDataXml()
        {
            var Client = ClientFactory.CreateClient();
            string FileStreamPath = $"{Env.ContentRootPath}\\wwwroot\\cached\\TranStarRoadWaySegmentDataStream.xml";

            var Request = CreateRequest(HoustonTranStarUriManager.GetLiveSpeedDataFeedAddressXml());
            var Response = await Client.SendAsync(Request, HttpCompletionOption.ResponseHeadersRead);

            using (var output = File.OpenWrite(FileStreamPath))
            using (var content = await Response.Content.ReadAsStreamAsync())
                await content.CopyToAsync(output);
        }

        private async Task GetLaneClosureDataXml()
        {
            LaneClosureDataModel LaneClosureDataModel = new LaneClosureDataModel();

            if (Env.EnvironmentName.Equals("Development"))
            {
                string FileStreamPath = $"{Env.ContentRootPath}\\wwwroot\\cached\\TranStarLaneClosureDataStream.xml";
                using (var StreamReader = new StreamReader(FileStreamPath))
                {
                    var Reader = XmlReader.Create(StreamReader);
                    var Serializer = new XmlSerializer(typeof(LaneClosureDataModel));
                    LaneClosureDataModel = (LaneClosureDataModel)Serializer.Deserialize(Reader);

                    var ListLaneClosures = new List<LaneClosure>();
                    var ListGroupedLaneClosures = new List<LaneClosure>();

                    foreach (LaneClosure LaneClosure in LaneClosureDataModel.LaneClosures)
                        ListLaneClosures.Add(LaneClosure);
                }
                await HoustonTranStarHub.Clients.All.SendAsync("updateLaneClosureData", LaneClosureDataModel, TimeZoneInfo.ConvertTime(DateTime.Now, TimeZoneInfo.FindSystemTimeZoneById("Central Standard Time")).ToString("MM/dd/yyyy HH:mm:ss"));
            }
            else
            {
                try
                {
                    using (StreamReader StreamReader = new StreamReader(await StreamLaneClosureDataAsync()))
                    {
                        var Reader = XmlReader.Create(StreamReader);
                        var Serializer = new XmlSerializer(typeof(LaneClosureDataModel));
                        LaneClosureDataModel = (LaneClosureDataModel)Serializer.Deserialize(Reader);

                        IList<LaneClosure> ListLaneClosures = new List<LaneClosure>();
                        IList<LaneClosure> ListGroupedLaneClosures = new List<LaneClosure>();
                        foreach (var LaneClosure in LaneClosureDataModel.LaneClosures)
                            ListLaneClosures.Add(LaneClosure);
                    }
                    await HoustonTranStarHub.Clients.All.SendAsync("updateLaneClosureData", LaneClosureDataModel, TimeZoneInfo.ConvertTime(DateTime.Now, TimeZoneInfo.FindSystemTimeZoneById("Central Standard Time")).ToString("MM/dd/yyyy HH:mm:ss"));
                }
                catch (Exception ex)
                {
                    await HoustonTranStarHub.Clients.All.SendAsync("exception", ex);
                }
            }
        }

        private async Task GetIncidentDataXml()
        {
            IncidentDataModel IncidentDataModel = new IncidentDataModel();

            if (Env.EnvironmentName.Equals("Development"))
            {
                string FileStreamPath = $"{Env.ContentRootPath}\\wwwroot\\cached\\TranStarIncidentDataStream.xml";
                using (var StreamReader = new StreamReader(FileStreamPath))
                {
                    var Reader = XmlReader.Create(StreamReader);
                    var Serializer = new XmlSerializer(typeof(IncidentDataModel));

                    IncidentDataModel = (IncidentDataModel)Serializer.Deserialize(Reader);

                    var Incidents = new List<Incident>();
                    var ListGroupedIncidents = new List<Incident>();

                    foreach (var Incident in IncidentDataModel.Incidents)
                        Incidents.Add(Incident);

                    IncidentDataModel.Incidents = new List<Incident>();

                    var GroupedIncidents = Incidents
                        .OrderByDescending(i => i.DetectionTimeElement.Value)
                        .GroupBy(i => i.RoadWayNameElement.Value)
                        .SelectMany((IGrouping<string, Incident> i) => i);

                    foreach (var item in GroupedIncidents)
                        ListGroupedIncidents.Add(item);

                    IncidentDataModel.Incidents = ListGroupedIncidents
                        .ToList();

                    await HoustonTranStarHub.Clients.All.SendAsync("updateIncidentData", IncidentDataModel, TimeZoneInfo.ConvertTime(DateTime.Now, TimeZoneInfo.FindSystemTimeZoneById("Central Standard Time")).ToString("MM/dd/yyyy HH:mm:ss"));
                }
            }
            else
            {
                try
                {
                    using (var StreamReader = new StreamReader(await StreamIncidentDateAsyc()))
                    {
                        var Reader = XmlReader.Create(StreamReader);
                        var Serializer = new XmlSerializer(typeof(IncidentDataModel));
                        IncidentDataModel = (IncidentDataModel)Serializer.Deserialize(Reader);

                        var Incidents = new List<Incident>();
                        var ListGroupedIncidents = new List<Incident>();

                        foreach (var Incident in IncidentDataModel.Incidents)
                            Incidents.Add(Incident);

                        IncidentDataModel.Incidents = new List<Incident>();

                        var GroupedIncidents = Incidents
                            .GroupBy(i => i.RoadWayNameElement.Value)
                            .SelectMany((IGrouping<string, Incident> i) => i);

                        foreach (var item in GroupedIncidents)
                            ListGroupedIncidents.Add(item);

                        IncidentDataModel.Incidents = ListGroupedIncidents
                            .ToList();

                        await HoustonTranStarHub.Clients.All.SendAsync("updateIncidentData", IncidentDataModel, TimeZoneInfo.ConvertTime(DateTime.Now, TimeZoneInfo.FindSystemTimeZoneById("Central Standard Time")).ToString("MM/dd/yyyy HH:mm:ss"));
                    }
                }
                catch (Exception ex)
                {
                    await HoustonTranStarHub.Clients.All.SendAsync("exception", ex);
                }
            }
        }

        private async Task GetSpeedTravelTimeDataXml()
        {
            var Client = ClientFactory.CreateClient();
            string FileStreamPath = $"{Env.ContentRootPath}\\wwwroot\\cached\\TranStarSpeedTravelTimeDataStream.xml";

            var Request = CreateRequest(HoustonTranStarUriManager.GetLiveTravelTimeDataFeedAddressXml());
            var Response = await Client.SendAsync(Request, HttpCompletionOption.ResponseHeadersRead);

            using (var output = File.OpenWrite(FileStreamPath))
            using (var content = await Response.Content.ReadAsStreamAsync())
                await content.CopyToAsync(output);
        }

        private async Task GetCameraListData()
        {
            var Client = ClientFactory.CreateClient();
            string FileStreamPath = $"{Env.ContentRootPath}\\wwwroot\\cached\\TranStarCameraListStream.xml";

            var Request = CreateRequest(HoustonTranStarUriManager.GetLiveCameraListDataFeedAddress());
            var Response = await Client.SendAsync(Request, HttpCompletionOption.ResponseHeadersRead);

            using (var output = File.OpenWrite(FileStreamPath))
            using (var content = await Response.Content.ReadAsStreamAsync())
                await content.CopyToAsync(output);
        }

        private async Task<Stream> StreamIncidentDateAsyc()
        {
            var Client = ClientFactory.CreateClient();

            var Request = CreateRequest(HoustonTranStarUriManager.GetLiveIncidentDataFeedAddressXml());
            var Response = await Client.SendAsync(Request, HttpCompletionOption.ResponseHeadersRead);

            return await Response.Content.ReadAsStreamAsync();
        }

        private async Task<Stream> StreamLaneClosureDataAsync()
        {
            var Client = ClientFactory.CreateClient();        

            var Request = CreateRequest(HoustonTranStarUriManager.GetLiveLaneClosureDataFeedAddressXml());
            var Response = await Client.SendAsync(Request, HttpCompletionOption.ResponseHeadersRead);

            return await Response.Content.ReadAsStreamAsync();
        }

        private static HttpRequestMessage CreateRequest(Uri Path)
        {
            return new HttpRequestMessage(HttpMethod.Get, Path.AbsoluteUri);
        }
    }
}