using System;
using System.Threading;
using System.Threading.Tasks;
using C19Tracking.ScheduledTasks.Enums; 
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging; 
using TaskFactory = C19Tracking.ScheduledTasks.Implement.TaskFactory;
namespace C19Tracking.ScheduledTasks
{
    public class ScheduledService : IHostedService, IDisposable
    {
        private int executionCount = 0;
        private readonly ILogger<ScheduledService> _logger;
        private readonly TaskResolver _taskResolver; 
        private Timer _timer;

        public ScheduledService(ILogger<ScheduledService> logger, TaskResolver taskResolver)
        {
            _logger = logger; 
            _taskResolver = taskResolver;
        }

        public Task StartAsync(CancellationToken stoppingToken)
        {
            _logger.LogInformation("Scheduled Service is running.");

            _timer = new Timer(DoWork, null, TimeSpan.Zero, TimeSpan.FromHours(1));
            TaskFactory taskFactory = new TaskFactory();
            foreach (FlowTask flowTask in Enum.GetValues(typeof( FlowTask)))
            {
                var taskbuider =  taskFactory.CreateInstant(flowTask.ToString(), _taskResolver);
                var result = taskbuider.Invoke(_logger).Result;
                if (!result)
                {
                    _logger.LogError($"Task was failed: { flowTask}");
                    break;
                }
            } 
            return Task.CompletedTask;
        }

        private void DoWork(object state)
        {
            var count = Interlocked.Increment(ref executionCount); 
            _logger.LogInformation("Scheduled Service is working. Count: {Count}", count);
        }

        public Task StopAsync(CancellationToken stoppingToken)
        {
            _logger.LogInformation("Scheduled Service is stopping."); 
            _timer?.Change(Timeout.Infinite, 0); 
            return Task.CompletedTask;
        }

        public void Dispose()
        {
            _timer?.Dispose();
        }
    }
}
 
