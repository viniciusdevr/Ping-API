using Microsoft.EntityFrameworkCore;
using Ping_API.Infrastructure.Data;
using PingAPI.Domain.Entities;
using PingAPI.Domain.Interfaces;

namespace Ping_API.Infrastructure.Repositories
{
    public class ReminderRepository : IReminderRepository
    {
        private readonly AppDbContext _context;

        public ReminderRepository(AppDbContext context)
        {
            _context = context;
        }
        public async Task<Reminder?> GetByIdAsync(int id)
        {
            return await _context.Reminders.FindAsync(id);
        }

        public async Task AddAsync(Reminder reminder)
        {
            await _context.Reminders.AddAsync(reminder);
            await _context.SaveChangesAsync();

            return;
        }

        public async Task UpdateAsync(Reminder reminder)
        {
            var originalReminder = await _context.Reminders.FindAsync(reminder.Id);
            if (originalReminder != null)
            {
                originalReminder.Update(reminder.Title, reminder.Description, reminder.NotificationDate, reminder.AdvanceNotice, reminder.Link);
            }
            await _context.SaveChangesAsync();
            return;
        }

        public async Task DeleteAsync(int id)
        {
            var reminder = await _context.Reminders.FindAsync(id);
            if (reminder != null)
            {
                _context.Reminders.Remove(reminder);
                await _context.SaveChangesAsync();
            }
            return;
        }

        public async Task<IEnumerable<Reminder>> GetAllAsync()
        {
            return await _context.Reminders.ToListAsync();
        }



    }
}
