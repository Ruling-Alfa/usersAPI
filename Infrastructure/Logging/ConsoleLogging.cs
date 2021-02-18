using Microsoft.Extensions.Configuration;
using Serilog;
using Serilog.Events;
using System;

namespace Infrastructure.Logging
{
    public class ConsoleLogging : IConsoleLogging
    {
        private Serilog.Core.Logger _logger;
        public ConsoleLogging()
        {
            _logger = new LoggerConfiguration()
            .MinimumLevel.Debug()
            .MinimumLevel.Override("Microsoft", LogEventLevel.Information)
            .Enrich.FromLogContext()
            .WriteTo.Console()
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
