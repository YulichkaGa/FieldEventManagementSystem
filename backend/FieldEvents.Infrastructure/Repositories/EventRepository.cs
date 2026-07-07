using Microsoft.EntityFrameworkCore;
using FieldEvents.Application.Interfaces;
using FieldEvents.Domain.Entities;
using FieldEvents.Infrastructure.Persistence;

namespace FieldEvents.Infrastructure.Repositories;

public class EventRepository : IEventRepository
{
    private readonly ApplicationDbContext _context;

    public EventRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task AddAsync(Event eventEntity)
    {
        await _context.Events.AddAsync(eventEntity);
    }

    public async Task SaveChangesAsync()
    {
        await _context.SaveChangesAsync();
    }
    public async Task<List<Event>> GetAllAsync()
    {
        return await _context.Events
            .OrderByDescending(e => e.CreatedAt)
            .ToListAsync();
    }
    public async Task<Event?> GetByIdAsync(Guid id)
    {
        return await _context.Events.FirstOrDefaultAsync(e => e.Id == id);
    }
}