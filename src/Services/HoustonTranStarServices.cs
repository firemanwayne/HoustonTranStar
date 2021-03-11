using HoustonTranStar.Concrete;
using HoustonTranStar.Entities;
using HoustonTranStar.Extensions;
using HoustonTranStar.Hubs;
using HoustonTranStar.Interface;
using Microsoft.AspNetCore.SignalR;
using Microsoft.Extensions.Hosting;
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
        readonly HttpClient Client;
        readonly IHostEnvironment Env;        
        readonly IHubContext<HoustonTranStarHub> Hub;
        static DateTime NowCST => TimeZoneInfo.ConvertTime(DateTime.UtcNow, TimeZoneInfo.FindSystemTimeZoneById("Central Standard Time"));

        public HoustonTranStarServices(
            IHostEnvironment Env,
            IHttpClientFactory Factory,
            IHubContext<HoustonTranStarHub> Hub)
        {
            this.Env = Env;
            this.Hub = Hub;

            Client = Factory.CreateClient();
        }

        public async Task UpdateCameras() => await GetCameraData();
        public async Task UpdateIncidents() => await GetIncidentDataXml();
        public async Task UpdateLaneClosures() => await GetLaneClosureDataXml();
        public async Task UpdateTravelTimes() => await GetSpeedTravelTimeDataXml();
        public async Task UpdateRoadwaySegments() => await GetRoadWaySegmentDataXml();


        async Task GetRoadWaySegmentDataXml()
        {
            var FileStreamPath = $"{Env.ContentRootPath}\\wwwroot\\cached\\TranStarRoadWaySegmentDataStream.xml";

            var Request = CreateRequest(HoustonTranStarUriManager.GetLiveSpeedDataFeedAddressXml());
            var Response = await Client.SendAsync(Request, HttpCompletionOption.ResponseHeadersRead);

            using var output = File.OpenWrite(FileStreamPath);
            using var content = await Response.Content.ReadAsStreamAsync();
            await content.CopyToAsync(output);
        }
        async Task GetLaneClosureDataXml()
        {
            var laneClosure = new LaneClosureDTO();

            if (Env.IsDevelopment())
            {
                var FileStreamPath = $"{Env.ContentRootPath}\\wwwroot\\cached\\TranStarLaneClosureDataStream.xml";
                using (StreamReader StreamReader = new(FileStreamPath))
                {
                    var Reader = XmlReader.Create(StreamReader);
                    var Serializer = new XmlSerializer(typeof(LaneClosureDTO));
                    laneClosure = (LaneClosureDTO)Serializer.Deserialize(Reader);

                    var laneClosures = new List<LaneClosure>();
                    var groupedLaneClosures = new List<LaneClosure>();

                    foreach (var LaneClosure in laneClosure.LaneClosures)
                        laneClosures.Add(LaneClosure);
                }

                await Hub.BroadCast(("updateLaneClosureData", (laneClosure, NowCST)));
            }
            else
            {
                try
                {
                    using (StreamReader StreamReader = new(await StreamLaneClosureDataAsync()))
                    {
                        var Reader = XmlReader.Create(StreamReader);
                        var Serializer = new XmlSerializer(typeof(LaneClosureDTO));
                        laneClosure = (LaneClosureDTO)Serializer.Deserialize(Reader);

                        IList<LaneClosure> ListLaneClosures = new List<LaneClosure>();
                        IList<LaneClosure> ListGroupedLaneClosures = new List<LaneClosure>();
                        foreach (var LaneClosure in laneClosure.LaneClosures)
                            ListLaneClosures.Add(LaneClosure);
                    }
                    await Hub.BroadCast(("updateLaneClosureData", (laneClosure, NowCST)));
                }
                catch (Exception ex)
                {
                    await Hub.BroadCast(("exception", (ex, NowCST)));
                }
            }
        }
        async Task GetIncidentDataXml()
        {
            var incident = new IncidentDTO();

            if (Env.IsDevelopment())
            {
                var FileStreamPath = $"{Env.ContentRootPath}\\wwwroot\\cached\\TranStarIncidentDataStream.xml";
                using var StreamReader = new StreamReader(FileStreamPath);
                var Reader = XmlReader.Create(StreamReader);
                var Serializer = new XmlSerializer(typeof(IncidentDTO));

                incident = (IncidentDTO)Serializer.Deserialize(Reader);

                var Incidents = new List<Incident>();
                var ListGroupedIncidents = new List<Incident>();

                foreach (var Incident in incident.Incidents)
                    Incidents.Add(Incident);

                incident.Incidents = new List<Incident>();

                var GroupedIncidents = Incidents
                    .OrderByDescending(i => i.DetectionTimeElement.Value)
                    .GroupBy(i => i.RoadWayNameElement.Value)
                    .SelectMany((IGrouping<string, Incident> i) => i);

                foreach (var item in GroupedIncidents)
                    ListGroupedIncidents.Add(item);

                incident.Incidents = ListGroupedIncidents
                    .ToList();

                await Hub.BroadCast(("updateIncidentData", (incident, NowCST)));               
            }
            else
            {
                try
                {
                    using var StreamReader = new StreamReader(await StreamIncidentDataAsyc());
                    var Reader = XmlReader.Create(StreamReader);
                    var Serializer = new XmlSerializer(typeof(IncidentDTO));
                    incident = (IncidentDTO)Serializer.Deserialize(Reader);

                    var Incidents = new List<Incident>();
                    var ListGroupedIncidents = new List<Incident>();

                    foreach (var Incident in incident.Incidents)
                        Incidents.Add(Incident);

                    incident.Incidents = new List<Incident>();

                    var GroupedIncidents = Incidents
                        .GroupBy(i => i.RoadWayNameElement.Value)
                        .SelectMany((IGrouping<string, Incident> i) => i);

                    foreach (var item in GroupedIncidents)
                        ListGroupedIncidents.Add(item);

                    incident.Incidents = ListGroupedIncidents
                        .ToList();

                    await Hub.BroadCast(("updateIncidentData", (incident, NowCST)));                   
                }
                catch (Exception ex)
                {
                    await Hub.BroadCast(("exception", (ex, NowCST)));
                }
            }
        }
        async Task GetSpeedTravelTimeDataXml()
        {
            var FileStreamPath = $"{Env.ContentRootPath}\\wwwroot\\cached\\TranStarSpeedTravelTimeDataStream.xml";

            var Request = CreateRequest(HoustonTranStarUriManager.GetLiveTravelTimeDataFeedAddressXml());
            var Response = await Client.SendAsync(Request, HttpCompletionOption.ResponseHeadersRead);

            using var output = File.OpenWrite(FileStreamPath);
            using var content = await Response.Content.ReadAsStreamAsync();
            await content.CopyToAsync(output);
        }

        async Task GetCameraData()
        {
            var FileStreamPath = $"{Env.ContentRootPath}\\wwwroot\\cached\\TranStarCameraListStream.xml";

            var Request = CreateRequest(HoustonTranStarUriManager.GetLiveCameraListDataFeedAddress());
            var Response = await Client.SendAsync(Request, HttpCompletionOption.ResponseHeadersRead);

            using var output = File.OpenWrite(FileStreamPath);
            using var content = await Response.Content.ReadAsStreamAsync();
            await content.CopyToAsync(output);
        }
        async Task<Stream> StreamIncidentDataAsyc()
        {
            var Request = CreateRequest(HoustonTranStarUriManager.GetLiveIncidentDataFeedAddressXml());
            var Response = await Client.SendAsync(Request, HttpCompletionOption.ResponseHeadersRead);

            return await Response.Content.ReadAsStreamAsync();
        }
        async Task<Stream> StreamLaneClosureDataAsync()
        {
            var Request = CreateRequest(HoustonTranStarUriManager.GetLiveLaneClosureDataFeedAddressXml());
            var Response = await Client.SendAsync(Request, HttpCompletionOption.ResponseHeadersRead);

            return await Response.Content.ReadAsStreamAsync();
        }

        static HttpRequestMessage CreateRequest(Uri Path) => new(HttpMethod.Get, Path.AbsoluteUri);        
    }
}