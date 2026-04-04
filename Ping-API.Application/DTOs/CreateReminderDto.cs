namespace Ping_API.Application.DTOs
{
    public class CreateReminderDto
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime NotificationDate { get; set; }
        public int AdvanceNotice { get; set; }
        public string? Link { get; set; }

    }
}
