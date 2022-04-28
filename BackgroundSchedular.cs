using Microsoft.Azure.Functions.Worker;
using Microsoft.Extensions.Logging;

namespace SchedularApp
{
    public class BackgroundSchedular
    {
        private readonly ILogger _logger;

        public BackgroundSchedular(ILoggerFactory loggerFactory)
        {
            _logger = loggerFactory.CreateLogger<BackgroundSchedular>();
        }

        [Function(nameof(BackgroundSchedular))]
        public void Run([TimerTrigger("*/2 * * * * *")] MyInfo myTimer)
        {
            _logger.LogInformation($"C# Timer trigger function executed at: {DateTime.Now}");

            //_logger.LogInformation(myTimer.ScheduleStatus.LastUpdated.Day.ToString());

            //_logger.LogInformation($"Next timer schedule at: {myTimer.ScheduleStatus.Next}");
        }
    }

    public class MyInfo
    {
        public MyScheduleStatus ScheduleStatus { get; set; }

        public bool IsPastDue { get; set; }
    }

    public class MyScheduleStatus
    {
        public DateTime Last { get; set; }

        public DateTime Next { get; set; }

        public DateTime LastUpdated { get; set; }
    }
}
