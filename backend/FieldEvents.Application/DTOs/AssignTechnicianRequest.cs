namespace FieldEvents.Application.DTOs;

public class AssignTechnicianRequest
{
    public Guid EventId { get; set; }

    public string TechnicianName { get; set; } = string.Empty;
}