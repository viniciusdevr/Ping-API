namespace Ping_API.Application.Interfaces
{
    public interface IReminderNotificationService
    {
        Task ProcessPendingRemindersAsync();
    }
}
