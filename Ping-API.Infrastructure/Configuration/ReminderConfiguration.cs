using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PingAPI.Domain.Entities;

namespace Ping_API.Infrastructure.Configuration
{
    public class ReminderConfiguration : IEntityTypeConfiguration<Reminder>
    {
        public void Configure(EntityTypeBuilder<Reminder> builder)
        {
            builder.ToTable("Reminders");

            builder.Property(b => b.Title)
                .IsRequired()
                .HasMaxLength(200);

            builder.Property(b => b.Description)
                .IsRequired(false)
                .HasMaxLength(1000);

            builder.Property(b => b.NotificationDate)
                .HasColumnType("datetime2")
                .IsRequired();

            builder.Property(b => b.AdvanceNotice)
                .IsRequired();

            builder.Property(b => b.Link)
                .IsRequired(false)
                .HasMaxLength(750);

            builder.Property(b => b.UpdatedAt)
                .HasColumnType("datetime2")
                .IsRequired(false);

            builder.Property(b => b.CreatedAt)
                .HasColumnType("datetime2")
                .IsRequired();

            builder.Property(b => b.IsNotified)
                .HasDefaultValue(false)
                .IsRequired();
        }
    }
}
