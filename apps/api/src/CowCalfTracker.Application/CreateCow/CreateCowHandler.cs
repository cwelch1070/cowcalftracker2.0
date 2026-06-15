using CowCalfTracker.Application.abstractions;
using CowCalfTracker.Application.Cows;
using CowCalfTracker.Domain.Cattle;

namespace CowCalfTracker.Application.CreateCow
{
    public sealed class CreateCowHandler(ICowRepository cowRepository)
    {
        public async Task<CowResponse> CreateAsync(string? name, int tagNumber, CancellationToken cancellationToken) {
            var cow = Cow.Create(name, tagNumber);

            var result = await cowRepository.AddAsync(cow, cancellationToken);

            return CowResponse.From(result);
        }
    }
}
