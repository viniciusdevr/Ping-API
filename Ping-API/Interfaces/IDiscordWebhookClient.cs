namespace Ping_API.Interfaces
{
    public interface IDiscordWebhookClient
    {
        Task SendAsync(string message);
    }
}
