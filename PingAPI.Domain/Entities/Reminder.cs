namespace PingAPI.Domain.Entities
{
    public class Reminder
    {

        public int Id { get; private set; }
        public string Title { get; private set; }
        public string Description { get; private set; }
        public DateTime NotificationDate { get; private set; }
        public int AdvanceNotice { get; private set; }
        public string? Link { get; private set; }
        public DateTime CreatedAt { get; private set; }
        public DateTime? UpdatedAt { get; private set; }

        public Reminder(string title, string description, DateTime notificationDate, int advanceNotice, string? link, DateTime createdAt)
        {
            Title = title;
            Description = description;
            NotificationDate = notificationDate;
            AdvanceNotice = advanceNotice;
            Link = link;
            CreatedAt = DateTime.UtcNow;
        }

        protected Reminder() { }

        public void Update(string title, string description, DateTime notificationDate, int advanceNotice, string? link)
        {
            Title = title;
            Description = description;
            NotificationDate = notificationDate;
            AdvanceNotice = advanceNotice;
            Link = link;
            UpdatedAt = DateTime.UtcNow;
        }


    }
}
