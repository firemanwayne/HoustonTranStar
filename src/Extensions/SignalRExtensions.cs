using Microsoft.AspNetCore.SignalR;
using System.Threading.Tasks;

namespace HoustonTranStar.Extensions
{
    public static class SignalRExtensions
    {
        public static async Task BroadCast<T>(this IHubContext<T> ctx, (string method, object data) p) where T : Hub
        {
            await ctx.Clients.All.SendAsync(p.method, p.data);
        }
    }
}
