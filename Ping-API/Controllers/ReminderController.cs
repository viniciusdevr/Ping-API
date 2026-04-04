using Microsoft.AspNetCore.Mvc;
using Ping_API.Application.DTOs;
using Ping_API.Application.Interfaces;

namespace Ping_API.Controllers
{
    [ApiController]
    [Route("api/reminders")]
    public class ReminderController : ControllerBase
    {
        private readonly IReminderService _service;

        public ReminderController(IReminderService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var reminders = await _service.GetAllAsync();
            return Ok(reminders);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var reminder = await _service.GetByIdAsync(id);
            if (reminder is null)
            {
                return NotFound();
            }
            return Ok(reminder);
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateReminderDto dto)
        {
            var createdReminder = await _service.CreateAsync(dto);
            return CreatedAtAction(nameof(GetById), new { id = createdReminder.Id }, createdReminder);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, UpdateReminderDto dto)
        {
            try
            {
                await _service.UpdateAsync(id, dto);
                return NoContent();
            }
            catch (KeyNotFoundException)
            {
                return NotFound();
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                await _service.DeleteAsync(id);
                return NoContent();
            }
            catch (KeyNotFoundException)
            {
                return NotFound();
            }

        }
    }
}
