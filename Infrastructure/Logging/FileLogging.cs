using Microsoft.Extensions.Configuration;
using Serilog;
using Serilog.Events;
using System;
using System.IO;

namespace Infrastructure.Logging
{
    public class FileLogging : IFileLogging
    {
        private Serilog.Core.Logger _logger;
        public FileLogging()
        {
            if (!Directory.Exists("Logging"))
            {
                Directory.CreateDirectory("Logging");
            }
            _logger = new LoggerConfiguration()
            .MinimumLevel.Debug()
            .MinimumLevel.Override("Microsoft", LogEventLevel.Information)
            .Enrich.FromLogContext()
            .WriteTo.File(@"Logging\log.txt",
                fileSizeLimitBytes: 1_000_000,
                rollOnFileSizeLimit: true,
                shared: true,
                flushToDiskInterval: TimeSpan.FromSeconds(1))
            .CreateLogger();
        }

        public void LogInfo(string info)
        {
            _logger.Information(info);
        }
        public void LogError(string info)
        {
            _logger.Error(info);
        }
    }
}
