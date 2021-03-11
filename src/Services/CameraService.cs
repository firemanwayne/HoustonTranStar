using HoustonTranStar.Abstract;
using HoustonTranStar.Concrete;
using HoustonTranStar.Hubs;
using HoustonTranStar.Interface;
using Microsoft.AspNetCore.SignalR;
using Microsoft.Extensions.Hosting;
using System.IO;
using System.Net.Http;
using System.Threading.Tasks;

namespace HoustonTranStar.Services
{
    public class CameraService : ReportServiceBase, IReportService
    {
        public CameraService(
            IHostEnvironment Env,
            IHttpClientFactory Factory,
            IHubContext<HoustonTranStarHub> Hub) : base(Env, Factory, Hub)
        {
        }

        public Task Update() => GetCameraData();

        async Task GetCameraData()
        {
            var FileStreamPath = $"{Env.ContentRootPath}\\wwwroot\\cached\\TranStarCameraListStream.xml";

            var Request = CreateRequest(HoustonTranStarUriManager.GetLiveCameraListDataFeedAddress());
            var Response = await Client.SendAsync(Request, HttpCompletionOption.ResponseHeadersRead);

            using var output = File.OpenWrite(FileStreamPath);
            using var content = await Response.Content.ReadAsStreamAsync();
            await content.CopyToAsync(output);
        }
    }
}
