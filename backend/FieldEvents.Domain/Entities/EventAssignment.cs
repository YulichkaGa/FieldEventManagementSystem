namespace FieldEvents.Domain.Entities;

public class EventAssignment
{
    public Guid Id { get; set; }

    public Guid EventId { get; set; }

    public Guid TechnicianId { get; set; }

    public Guid AssignedByUserId { get; set; }

    public DateTime AssignedAt { get; set; } = DateTime.UtcNow;
}