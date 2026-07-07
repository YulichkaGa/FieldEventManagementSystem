namespace FieldEvents.Application.DTOs;

public class EventDto
{
    public Guid Id { get; set; }

    public string Title { get; set; } = string.Empty;

    public string Description { get; set; } = string.Empty;

    public string Source { get; set; } = string.Empty;

    public string Location { get; set; } = string.Empty;

    public DateTime CreatedAt { get; set; }
}