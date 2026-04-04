using PingAPI.Domain.Entities;

namespace PingAPI.Domain.Interfaces
{
    public interface IReminderRepository
    {
        Task<Reminder?> GetByIdAsync(int id);
        Task<IEnumerable<Reminder>> GetAllAsync();
        Task AddAsync(Reminder reminder);
        Task UpdateAsync(Reminder reminder);
        Task DeleteAsync(int id);
    }
}
