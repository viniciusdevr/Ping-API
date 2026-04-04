namespace Ping_API.Application.DTOs
{
    public class UpdateReminderDto
    {
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public DateTime NotificationDate { get; set; }
        public int AdvanceNotice { get;  set; }
        public string? Link { get; set; }


    }
}
