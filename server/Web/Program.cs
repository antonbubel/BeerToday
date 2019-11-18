namespace BeerToday.Web.API
{
    using System;

    using Microsoft.AspNetCore;
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.Extensions.Logging;

    using NLog;
    using NLog.Web;
    using LogLevel = Microsoft.Extensions.Logging.LogLevel;

    public class Program
    {
        public static void Main(string[] args)
        {
            var logger = NLogBuilder
                .ConfigureNLog("NLog.config")
                .GetCurrentClassLogger();

            try
            {
                logger.Info("Creating WebHostBuilder, running the application");

                var webHostBuilder = CreateWebHostBuilder(args);
                var webHost = webHostBuilder.Build();

                webHost.Run();
            }
            catch (Exception exception)
            {
                logger.Error(exception, "Execution stopped because of exception");

                throw;
            }
            finally
            {
                // Ensure to flush and stop internal timers/threads before application-exit (Avoid segmentation fault on Linux)
                LogManager.Shutdown();
            }
        }

        private static IWebHostBuilder CreateWebHostBuilder(string[] args)
        {
            return WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>()
                .ConfigureLogging(ConfigureLogging)
                .UseNLog();
        }

        private static void ConfigureLogging(ILoggingBuilder logging)
        {
            logging.ClearProviders();
            logging.SetMinimumLevel(LogLevel.Trace);
        }
    }
}

