using Microsoft.Extensions.Logging;

namespace SmartTestProj.BLL.BackgroundServices
{
    public class LoggingService
    {
        private readonly ILogger<LoggingService> _logger;

        public LoggingService(ILogger<LoggingService> logger)
        {
            _logger = logger;
        }

        public void LogMessage(string message)
        {
            _logger.LogInformation($"{message} at {DateTime.Now.ToString()}");
        }
    }
}
