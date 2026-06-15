using CowCalfTracker.Application.abstractions;
using CowCalfTracker.Application.Cows;

namespace CowCalfTracker.Application.GetCow;

public sealed class GetCowHandler(ICowRepository cowRepository)
{
    public async Task<CowResponse?> GetByIdAsync(Guid id, CancellationToken cancellationToken)
    {
        var cow = await cowRepository.GetByIdAsync(id, cancellationToken);

        return cow is null
            ? null
            : CowResponse.From(cow);
    }
}
