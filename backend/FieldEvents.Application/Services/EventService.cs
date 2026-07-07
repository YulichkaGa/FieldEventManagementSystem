using FieldEvents.Application.DTOs;
using FieldEvents.Application.Interfaces;
using FieldEvents.Domain.Entities;

namespace FieldEvents.Application.Services;

public class EventService : IEventService
{
    private readonly IEventRepository _eventRepository;

    public EventService(IEventRepository eventRepository)
    {
        _eventRepository = eventRepository;
    }

    public async Task<Guid> CreateEventAsync(CreateEventRequest request)
    {
        var eventEntity = new Event
        {
            Id = Guid.NewGuid(),
            Title = request.Title,
            Description = request.Description,
            Source = request.Source,
            Location = request.Location
        };

        await _eventRepository.AddAsync(eventEntity);
        await _eventRepository.SaveChangesAsync();

        return eventEntity.Id;
    }

    public async Task<List<EventDto>> GetAllAsync()
    {
        var events = await _eventRepository.GetAllAsync();

        return events.Select(e => new EventDto
        {
            Id = e.Id,
            Title = e.Title,
            Description = e.Description,
            Source = e.Source,
            Location = e.Location,
            CreatedAt = e.CreatedAt
        }).ToList();
    }
    public async Task AssignTechnicianAsync(AssignTechnicianRequest request)
    {
        var eventEntity = await _eventRepository.GetByIdAsync(request.EventId);

        if (eventEntity == null)
        {
            throw new InvalidOperationException("Event not found");
        }

        eventEntity.AssignedTechnician = request.TechnicianName;
        eventEntity.Status = FieldEvents.Domain.Enums.EventStatus.Assigned;
        eventEntity.UpdatedAt = DateTime.UtcNow;

        await _eventRepository.SaveChangesAsync();
    }
}