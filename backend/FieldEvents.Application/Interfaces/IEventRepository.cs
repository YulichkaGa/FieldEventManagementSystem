using FieldEvents.Domain.Entities;

public interface IEventRepository
{
    Task AddAsync(Event eventEntity);

    Task<List<Event>> GetAllAsync();

    Task SaveChangesAsync();
    Task<Event?> GetByIdAsync(Guid id);

}