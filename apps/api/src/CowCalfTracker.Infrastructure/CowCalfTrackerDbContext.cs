using CowCalfTracker.Domain.Cattle;
using Microsoft.EntityFrameworkCore;

namespace CowCalfTracker.Infrastructure;

public sealed class CowCalfTrackerDbContext(DbContextOptions<CowCalfTrackerDbContext> options) : DbContext(options)
{
    public DbSet<Cow> Cows => Set<Cow>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(CowCalfTrackerDbContext).Assembly);
        base.OnModelCreating(modelBuilder);
    }
}