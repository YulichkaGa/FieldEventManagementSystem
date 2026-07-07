namespace FieldEvents.Domain.Entities;

public class Technician
{
    public Guid Id { get; set; }

    public Guid UserId { get; set; }

    public bool IsConnected { get; set; }

    public DateTime? LastSeenAt { get; set; }
}