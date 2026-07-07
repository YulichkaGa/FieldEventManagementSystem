using FieldEvents.Api.Hubs;
using FieldEvents.Application.DTOs;
using FieldEvents.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;

namespace FieldEvents.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class EventsController : ControllerBase
{
    private readonly IEventService _eventService;
    private readonly IHubContext<EventsHub> _hubContext;

    public EventsController(
        IEventService eventService,
        IHubContext<EventsHub> hubContext)
    {
        _eventService = eventService;
        _hubContext = hubContext;
    }

    [HttpPost]
    public async Task<IActionResult> CreateEvent([FromBody] CreateEventRequest request)
    {
        var eventId = await _eventService.CreateEventAsync(request);

        await _hubContext.Clients.All.SendAsync("EventCreated", new
        {
            EventId = eventId,
            request.Title,
            request.Description,
            request.Source,
            request.Location,
            CreatedAt = DateTime.UtcNow
        });

        return Ok(new
        {
            EventId = eventId,
            Message = "Event created successfully"
        });
    }
    [HttpGet]
    public async Task<IActionResult> GetEvents()
    {
        var events = await _eventService.GetAllAsync();

        return Ok(events);
    }

    [HttpPut("assign")]
    public async Task<IActionResult> AssignTechnician(
    [FromBody] AssignTechnicianRequest request)
    {
        await _eventService.AssignTechnicianAsync(request);

        await _hubContext.Clients.All.SendAsync("TechnicianAssigned", new
        {
            request.EventId,
            request.TechnicianName
        });

        return Ok(new
        {
            Message = "Technician assigned successfully"
        });
    }
}