using HoustonTranStar.Abstract;
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
    public class IncidentService : ReportServiceBase, IReportService
    {
        public IncidentService(
            IHostEnvironment Env,
            IHttpClientFactory Factory,
            IHubContext<HoustonTranStarHub> Hub) : base(Env, Factory, Hub)
        {
        }

        public Task Update() => IsDevelopment ? GetIncidentDataXml() : GetIncidentData();

        async Task GetIncidentData()
        {
            var incident = new IncidentDTO();
            var incidents = new List<Incident>();
            var groupedIncidents = new List<Incident>();

            try
            {
                using var StreamReader = new StreamReader(await StreamDataAsyc());
                var Reader = XmlReader.Create(StreamReader);
                var Serializer = new XmlSerializer(typeof(IncidentDTO));
                incident = (IncidentDTO)Serializer.Deserialize(Reader);

                foreach (var i in incident.Incidents)
                    incidents.Add(i);

                incident.Incidents = new List<Incident>();

                var GroupedIncidents = incidents
                    .GroupBy(i => i.RoadWayNameElement.Value)
                    .SelectMany((IGrouping<string, Incident> i) => i);

                foreach (var item in GroupedIncidents)
                    groupedIncidents.Add(item);

                incident.Incidents = groupedIncidents
                    .ToList();

                await Hub.BroadCast(("updateIncidentData", (incident, NowCST)));
            }
            catch (Exception ex)
            {
                await Hub.BroadCast(("exception", (ex, NowCST)));
            }
        }
        async Task GetIncidentDataXml()
        {
            var incident = new IncidentDTO();
            var incidents = new List<Incident>();
            var groupedIncidents = new List<Incident>();

            var fileStreamPath = $"{Env.ContentRootPath}\\wwwroot\\cached\\TranStarIncidentDataStream.xml";
            using var streamReader = new StreamReader(fileStreamPath);
            var reader = XmlReader.Create(streamReader);
            var serializer = new XmlSerializer(typeof(IncidentDTO));

            incident = (IncidentDTO)serializer.Deserialize(reader);

            foreach (var Incident in incident.Incidents)
                incidents.Add(Incident);

            incident.Incidents = new List<Incident>();

            var GroupedIncidents = incidents
                .OrderByDescending(i => i.DetectionTimeElement.Value)
                .GroupBy(i => i.RoadWayNameElement.Value)
                .SelectMany((IGrouping<string, Incident> i) => i);

            foreach (var item in GroupedIncidents)
                groupedIncidents.Add(item);

            incident.Incidents = groupedIncidents
                .ToList();

            await Hub.BroadCast(("updateIncidentData", (incident, NowCST)));
        }
        async Task<Stream> StreamDataAsyc()
        {
            var Request = CreateRequest(HoustonTranStarUriManager.GetLiveIncidentDataFeedAddressXml());

            var Response = await Client.SendAsync(
                Request,
                HttpCompletionOption.ResponseHeadersRead);

            return await Response.Content.ReadAsStreamAsync();
        }
    }
}
