using CowCalfTracker.Application.abstractions;
using CowCalfTracker.Domain.Cattle;
using Microsoft.EntityFrameworkCore;

namespace CowCalfTracker.Infrastructure;

public sealed class CowRepository(CowCalfTrackerDbContext dbContext) : ICowRepository
{
    public async Task<Cow?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default)
    {
        return await dbContext.Cows.FirstOrDefaultAsync(cow => cow.Id == id, cancellationToken);
    }

    public async Task<Cow> AddAsync(Cow cow, CancellationToken cancellationToken = default)
    {
        await dbContext.Cows.AddAsync(cow, cancellationToken);
        await dbContext.SaveChangesAsync(cancellationToken);

        return cow;
    }
}