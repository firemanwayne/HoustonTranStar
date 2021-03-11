using HoustonTranStar.Hubs;
using Microsoft.AspNetCore.SignalR;
using Microsoft.Extensions.Hosting;
using System;
using System.Net.Http;

namespace HoustonTranStar.Abstract
{
    public abstract class ReportServiceBase
    {
        public ReportServiceBase(
            IHostEnvironment Env,
            IHttpClientFactory Factory,
            IHubContext<HoustonTranStarHub> Hub)
        {
            this.Env = Env;
            this.Hub = Hub;

            Client = Factory.CreateClient();

            IsDevelopment = Env.IsDevelopment();
        }
        protected bool IsDevelopment { get; }
        protected HttpClient Client { get; }
        protected IHostEnvironment Env { get; }
        protected IHubContext<HoustonTranStarHub> Hub { get; }
        protected static HttpRequestMessage CreateRequest(Uri Path) => new(HttpMethod.Get, Path.AbsoluteUri);
        protected static DateTime NowCST => TimeZoneInfo.ConvertTime(DateTime.UtcNow, TimeZoneInfo.FindSystemTimeZoneById("Central Standard Time"));        
    }
}
