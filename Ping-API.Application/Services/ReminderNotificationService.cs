using Microsoft.Extensions.Logging;
using Ping_API.Application.Interfaces;
using PingAPI.Domain.Entities;
using PingAPI.Domain.Interfaces;

namespace Ping_API.Application.Services
{
    public class ReminderNotificationService : IReminderNotificationService
    {
        private readonly IReminderRepository _repository;
        private readonly IDiscordWebhookClient _discordClient;
        private readonly ILogger<ReminderNotificationService> _logger;

        public ReminderNotificationService(IReminderRepository repository, IDiscordWebhookClient discordClient, ILogger<ReminderNotificationService> logger)
        {
            _repository = repository;
            _discordClient = discordClient;
            _logger = logger;
        }

        public async Task ProcessPendingRemindersAsync()
        {
            var pending = await _repository.GetPendingAsync();

            _logger.LogInformation("Reminders pendentes encontrados: {Count}", pending.Count());


            var dueReminders = pending.Where(r =>
                r.NotificationDate.AddMinutes(-r.AdvanceNotice) <= DateTime.UtcNow);

            _logger.LogInformation("Reminders prontos para disparar: {Count}", dueReminders.Count());


            foreach (var reminder in dueReminders)
            {
                try
                {
                    var message = BuildMessage(reminder);

                    await _discordClient.SendAsync(message);

                    reminder.Notificated();
                    await _repository.UpdateAsync(reminder);

                    _logger.LogInformation(
                        "Reminder {id} - '{Title}' sent successfully.",
                        reminder.Id, reminder.Title);
                }
                catch (Exception ex)
                {
                    _logger.LogError(ex,
                        "Reminder notification Error {Id} - '{Title}' failed to send.", reminder.Id, reminder.Title);
                }
            }
        }

        private static string BuildMessage(Reminder reminder)
        {
            var message = $"**{reminder.Title}**\n{reminder.Description}";

            if (!string.IsNullOrWhiteSpace(reminder.Link))
            {
                message += $"\n{reminder.Link}";
            }
            return message;
        }
    }
}
