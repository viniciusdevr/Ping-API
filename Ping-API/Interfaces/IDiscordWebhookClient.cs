namespace Ping_API.Application.Interfaces
{
    public interface IDiscordWebhookClient
    {
        Task SendAsync(string message);
    }
}
