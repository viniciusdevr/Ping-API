using Microsoft.Extensions.Configuration;
using Ping_API.Application.Interfaces;
using System.Text;
using System.Text.Json;

namespace Ping_API.Infrastructure.ExternalServices
{
    public class DiscordWebhookClient : IDiscordWebhookClient
    {
        private readonly HttpClient _httpClient;
        private readonly string _webhookUrl;

        public DiscordWebhookClient(HttpClient httpClient, IConfiguration configuration)
        {
            _httpClient = httpClient;
            _webhookUrl = configuration["Discord:WebhookUrl"]
                ?? throw new InvalidOperationException("Discord:WebhookUrl not configured.");
        }

        public async Task SendAsync(string message)
        {
            var payload = new { content = message };

            var json = JsonSerializer.Serialize(payload);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            var response = await _httpClient.PostAsync(_webhookUrl, content);

            response.EnsureSuccessStatusCode();
        }
    }
}
