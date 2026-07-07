using FieldEvents.Domain.Enums;

namespace FieldEvents.Domain.Entities;

public class EventStatusHistory
{
    public Guid Id { get; set; }

    public Guid EventId { get; set; }

    public EventStatus Status { get; set; }

    public Guid ChangedByUserId { get; set; }

    public DateTime ChangedAt { get; set; } = DateTime.UtcNow;
}