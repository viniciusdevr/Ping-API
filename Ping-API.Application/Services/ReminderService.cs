using Ping_API.Application.DTOs;
using Ping_API.Application.Interfaces;
using Ping_API.Application.Mappers;
using PingAPI.Domain.Interfaces;

namespace Ping_API.Application.Services
{
    public class ReminderService : IReminderService
    {
        private readonly IReminderRepository _repository;

        public ReminderService(IReminderRepository repository)
        {
            _repository = repository;
        }

        public async Task<ReminderResponseDto> CreateAsync(CreateReminderDto dto)
        {
            var reminder = ReminderMapper.ToEntity(dto);
            await _repository.AddAsync(reminder);
            return ReminderMapper.ToDto(reminder);
        }

        public async Task DeleteAsync(int id)
        {
            var reminder = await _repository.GetByIdAsync(id);
            if (reminder is null)
            {
                throw new KeyNotFoundException($"Reminder with id {id} not found.");
            }
            await _repository.DeleteAsync(id);
        }

        public async Task<IEnumerable<ReminderResponseDto>> GetAllAsync()
        {
            var reminders = await _repository.GetAllAsync();

            return reminders.Select(ReminderMapper.ToDto);
        }

        public async Task<ReminderResponseDto?> GetByIdAsync(int id)
        {
            var reminder = await _repository.GetByIdAsync(id);
            if (reminder is null)
            {
                throw new KeyNotFoundException($"Reminder with id {id} not found.");
            }
            return ReminderMapper.ToDto(reminder);
        }

        public async Task UpdateAsync(int id, UpdateReminderDto dto)
        {
            var reminder = await _repository.GetByIdAsync(id);

            if (reminder is null)
            {
                throw new KeyNotFoundException($"Reminder with id {id} not found.");
            }
            reminder.Update(
                dto.Title,
                dto.Description,
                dto.NotificationDate,
                dto.AdvanceNotice,
                dto.Link
            );

            await _repository.UpdateAsync(reminder);
        }
    }
}
