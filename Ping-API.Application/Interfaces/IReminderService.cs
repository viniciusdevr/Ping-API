using Ping_API.Application.DTOs;

namespace Ping_API.Application.Interfaces
{
    public interface IReminderService
    {
        Task<ReminderResponseDto?> GetByIdAsync(int id);
        Task<IEnumerable<ReminderResponseDto?>> GetAllAsync();
        Task<ReminderResponseDto> CreateAsync(CreateReminderDto dto);
        Task UpdateAsync(int id, UpdateReminderDto dto);
        Task DeleteAsync(int id);
    }
}
