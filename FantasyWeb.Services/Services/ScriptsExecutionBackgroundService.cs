using Microsoft.Extensions.Hosting;
using System.Diagnostics;

namespace FantasyWeb.Services.Services
{
    public class ScriptsExecutionBackgroundService : IHostedService
    {
        private Timer? _timer = null;
        private bool _isRunning = false;

        public Task StartAsync(CancellationToken cancellationToken)
        {
            _timer = new Timer(DoWork, null, TimeSpan.Zero, TimeSpan.FromSeconds(30));

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
            //if (_isRunning)
            //{
            //    return;
            //}

            //ProcessStartInfo startInfo = new ProcessStartInfo();
            //startInfo.UseShellExecute = false;
            //startInfo.FileName = "D:\\Programming\\FantasyWeb\\webapi\\scripts\\dist\\main\\main.exe";
            //startInfo.WindowStyle = ProcessWindowStyle.Hidden;
            //startInfo.RedirectStandardOutput = true;

            //using (Process process = Process.Start(startInfo))
            //{
            //    _isRunning = true;
            //    using (StreamReader reader = process.StandardOutput)
            //    {
            //        string result = reader.ReadToEnd();
            //        Debug.WriteLine(result);
            //    }
            //}
        }
    }
}
