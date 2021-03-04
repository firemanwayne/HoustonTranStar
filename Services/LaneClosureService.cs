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
using System.Net.Http;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;

namespace HoustonTranStar.Services
{
    public class LaneClosureService : ReportServiceBase, IReportService
    {
        public LaneClosureService(
            IHostEnvironment Env,
            IHttpClientFactory Factory,
            IHubContext<HoustonTranStarHub> Hub) : base(Env, Factory, Hub)
        {
        }

        public Task Update() => IsDevelopment ? GetLaneClosureDataXml() : GetLaneClosureData();        

        async Task GetLaneClosureData()
        {
            try
            {
                var laneClosure = new LaneClosureDTO();
                var ListLaneClosures = new List<LaneClosure>();
                var ListGroupedLaneClosures = new List<LaneClosure>();

                using (StreamReader StreamReader = new(await StreamLaneClosureDataAsync()))
                {
                    var Reader = XmlReader.Create(StreamReader);
                    var Serializer = new XmlSerializer(typeof(LaneClosureDTO));
                    laneClosure = (LaneClosureDTO)Serializer.Deserialize(Reader);

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
        async Task GetLaneClosureDataXml()
        {
            try
            {
                var laneClosure = new LaneClosureDTO();
                var laneClosures = new List<LaneClosure>();
                var groupedLaneClosures = new List<LaneClosure>();

                var FileStreamPath = $"{Env.ContentRootPath}\\wwwroot\\cached\\TranStarLaneClosureDataStream.xml";
                using (var streamReader = new StreamReader(FileStreamPath))
                {
                    var Reader = XmlReader.Create(streamReader);
                    var Serializer = new XmlSerializer(typeof(LaneClosureDTO));
                    laneClosure = (LaneClosureDTO)Serializer.Deserialize(Reader);

                    foreach (var LaneClosure in laneClosure.LaneClosures)
                        laneClosures.Add(LaneClosure);
                }

                await Hub.BroadCast(("updateLaneClosureData", (laneClosure, NowCST)));
            }
            catch(Exception ex)
            {
                await Hub.BroadCast(("exception", (ex, NowCST)));
            }
        }
        async Task<Stream> StreamLaneClosureDataAsync()
        {
            var Request = CreateRequest(HoustonTranStarUriManager.GetLiveLaneClosureDataFeedAddressXml());
            var Response = await Client.SendAsync(Request, HttpCompletionOption.ResponseHeadersRead);

            return await Response.Content.ReadAsStreamAsync();
        }
    }
}
