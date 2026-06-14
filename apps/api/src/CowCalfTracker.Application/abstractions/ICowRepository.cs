using CowCalfTracker.Domain.Cattle;

namespace CowCalfTracker.Application.abstractions;

public interface ICowRepository
{
    Task<Cow?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default);
    Task<Cow> AddAsync(Cow cow, CancellationToken cancellationToken = default);
}