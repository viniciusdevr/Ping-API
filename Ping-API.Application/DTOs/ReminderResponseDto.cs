namespace Ping_API.Application.DTOs
{
    public record ReminderResponseDto(
        int Id,
        string Title,
        string Description,
        DateTime NotificationDate,
        int AdvanceNotice,
        string? Link,
        DateTime CreatedAt
    );


}
