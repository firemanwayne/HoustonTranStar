using Microsoft.Extensions.Hosting;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace HoustonTranStar.Abstract
{
    public abstract class HostedService : IHostedService, IDisposable
    {
        private Task ExecutingTask;
        private readonly CancellationTokenSource CancellationTokenSource = new CancellationTokenSource();
        protected const int MaxNumberRetries = 10;

        public abstract Task ExecuteAsync(CancellationToken StoppingToken);

        public Task StartAsync(CancellationToken StoppingToken)
        {
            ExecutingTask = ExecuteAsync(StoppingToken);
            if (ExecutingTask.IsCompleted)
                return ExecutingTask;

            return Task.CompletedTask;
        }

        public async Task StopAsync(CancellationToken cancellationToken)
        {
            if (ExecutingTask == null)
                return;
            try
            {
                CancellationTokenSource.Cancel();
            }
            finally
            {
                await Task.WhenAny(ExecutingTask, Task.Delay(Timeout.Infinite, cancellationToken));
            }
        }

        public void Dispose()
        {
            CancellationTokenSource.Cancel();
        }

        public DateTime NowCST()
        {
            return TimeZoneInfo.ConvertTime(DateTime.Now, TimeZoneInfo.FindSystemTimeZoneById("Central Standard Time"));
        }
    }
}