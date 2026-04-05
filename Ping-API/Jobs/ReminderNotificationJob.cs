using Ping_API.Application.Interfaces;

namespace Ping_API.Jobs
{
    public class ReminderNotificationJob : BackgroundService
    {
        private readonly IServiceScopeFactory _scopeFactory;
        private readonly ILogger<ReminderNotificationJob> _logger;
        private readonly TimeSpan _interval = TimeSpan.FromMinutes(1);

        public ReminderNotificationJob(
            IServiceScopeFactory scopeFactory,
            ILogger<ReminderNotificationJob> logger)
        {
            _scopeFactory = scopeFactory;
            _logger = logger;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            _logger.LogInformation("ReminderNotificationJob initializes");

            while (!stoppingToken.IsCancellationRequested)
            {
                _logger.LogInformation("Verifying pending reminders...");
                
                try
                {
                    await ProcessAsync();
                }
                catch (Exception ex)
                {
                    _logger.LogError(ex, "Unexpected error in ReminderNotificationJob");
                }

                try
                {
                    await Task.Delay(_interval, stoppingToken);
                }
                catch (OperationCanceledException)
                {
                    // Expected when stoppingToken is canceled during application shutdown
                    _logger.LogInformation("ReminderNotificationJob cancellation requested");
                    break;
                }
            }
            _logger.LogInformation("ReminderNotificationJob closed");
        }

        private async Task ProcessAsync()
        {
            using var scope = _scopeFactory.CreateScope();

            var notificationService = scope.ServiceProvider.GetRequiredService<IReminderNotificationService>();

            await notificationService.ProcessPendingRemindersAsync();
        }
    }
}
