using FieldEvents.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace FieldEvents.Infrastructure.Persistence;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }

    public DbSet<Event> Events => Set<Event>();
    public DbSet<User> Users => Set<User>();
    public DbSet<Technician> Technicians => Set<Technician>();
    public DbSet<EventAssignment> EventAssignments => Set<EventAssignment>();
    public DbSet<EventStatusHistory> EventStatusHistories => Set<EventStatusHistory>();
    public DbSet<PushSubscription> PushSubscriptions => Set<PushSubscription>();
}