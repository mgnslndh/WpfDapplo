
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.IO;
using System.Threading.Tasks;
using Dapplo.Microsoft.Extensions.Hosting.AppServices;
using Dapplo.Microsoft.Extensions.Hosting.Wpf;
using Microsoft.Extensions.DependencyInjection;

namespace ObjectDisposed
{
    public static class Program
    {
        public static Task Main(string[] args)
        {
            var host = new HostBuilder()
                .ConfigureLogging()
                .ConfigureWpf(wpfBuilder => {
                    wpfBuilder.UseApplication<App>();
                    wpfBuilder.UseWindow<MainWindow>();
                })
                .UseWpfLifetime()
                .UseConsoleLifetime()
                .Build();

            Console.WriteLine("Run!");

            return host.RunAsync();
        }

        /// <summary>
        /// Configure the loggers
        /// </summary>
        /// <param name="hostBuilder">IHostBuilder</param>
        /// <returns>IHostBuilder</returns>
        private static IHostBuilder ConfigureLogging(this IHostBuilder hostBuilder) =>
            hostBuilder.ConfigureLogging((hostContext, configLogging) =>
            {
                configLogging
                    .AddConfiguration(hostContext.Configuration.GetSection("Logging"))
                    .AddConsole()
                    .AddDebug();
            });
    }
}