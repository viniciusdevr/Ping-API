using Microsoft.EntityFrameworkCore;
using Ping_API.Application.Interfaces;
using Ping_API.Application.Services;
using Ping_API.Infrastructure.Data;
using Ping_API.Infrastructure.ExternalServices;
using Ping_API.Infrastructure.Repositories;
using Ping_API.Jobs;
using PingAPI.Domain.Interfaces;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();

builder.Services.AddScoped<IReminderRepository, ReminderRepository>();
builder.Services.AddScoped<IReminderService, ReminderService>();
builder.Services.AddHostedService<ReminderNotificationJob>();
builder.Services.AddScoped<IReminderNotificationService, ReminderNotificationService>();
builder.Services.AddHttpClient<IDiscordWebhookClient, DiscordWebhookClient>();
builder.Services.AddScoped<IReminderNotificationService, ReminderNotificationService>();
builder.Services.AddHostedService<ReminderNotificationJob>();



var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

builder.Services.AddDbContext<AppDbContext>(options => options.UseSqlServer(connectionString));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
