using Ping_API.Application.DTOs;
using PingAPI.Domain.Entities;

namespace Ping_API.Application.Mappers
{
    public static class ReminderMapper
    {
        public static ReminderResponseDto ToDto(Reminder reminder) => new(
            reminder.Id,
            reminder.Title,
            reminder.Description,
            reminder.NotificationDate,
            reminder.AdvanceNotice,
            reminder.Link,
            reminder.CreatedAt
            );

        public static Reminder ToEntity(CreateReminderDto dto) => new(
            dto.Title,
            dto.Description,
            dto.NotificationDate,
            dto.AdvanceNotice,
            dto.Link,
            DateTime.UtcNow
            );
    }
}
