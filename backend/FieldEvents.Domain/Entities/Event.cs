using FieldEvents.Domain.Enums;

namespace FieldEvents.Domain.Entities;

public class Event
{
    public Guid Id { get; set; }

    public string Title { get; set; } = string.Empty;

    public string Description { get; set; } = string.Empty;

    public string Source { get; set; } = string.Empty;

    public string Location { get; set; } = string.Empty;

    public EventStatus Status { get; set; } = EventStatus.New;

    public EventPriority Priority { get; set; } = EventPriority.Normal;

    public Guid? AssignedTechnicianId { get; set; }

    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

    public DateTime? UpdatedAt { get; set; }

    public DateTime? ClosedAt { get; set; }
    public string? AssignedTechnician { get; set; }

}