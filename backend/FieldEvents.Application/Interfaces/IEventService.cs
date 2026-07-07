using FieldEvents.Application.DTOs;

namespace FieldEvents.Application.Interfaces;

public interface IEventService
{
    Task<Guid> CreateEventAsync(CreateEventRequest request);
    Task<List<EventDto>> GetAllAsync();
    Task AssignTechnicianAsync(AssignTechnicianRequest request);
}