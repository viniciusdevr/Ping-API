using Microsoft.EntityFrameworkCore;
using Ping_API.Infrastructure.Configuration;
using PingAPI.Domain.Entities;

namespace Ping_API.Infrastructure.Data
{
    public class AppDbContext : DbContext
    {
        public DbSet<Reminder> Reminders { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfiguration(new ReminderConfiguration());
        }
    }
}
