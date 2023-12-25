using Microsoft.Extensions.Hosting;
using System.Diagnostics;
using System.Reflection;
using System.Reflection.Emit;
using static System.Net.Mime.MediaTypeNames;

namespace FantasyWeb.Services.Services
{
    public class ScriptsExecutionBackgroundService : IHostedService
    {
        private Timer? _timer = null;
        private bool _isRunning = false;

        public Task StartAsync(CancellationToken cancellationToken)
        {
            _timer = new Timer(DoWork, null, TimeSpan.Zero, TimeSpan.FromSeconds(86400));

            return Task.CompletedTask;
        }

        public Task StopAsync(CancellationToken stoppingToken)
        {
            _timer?.Change(Timeout.Infinite, 0);

            return Task.CompletedTask;
        }

        public void Dispose()
        {
            _timer?.Dispose();
        }

        private void DoWork(object? state)
        {
            //string directory = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            //Process.Start($"{directory}\\scripts\\main.exe");
        }
    }
}
