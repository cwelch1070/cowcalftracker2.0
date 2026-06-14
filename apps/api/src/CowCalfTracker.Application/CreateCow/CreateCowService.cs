using CowCalfTracker.Application.abstractions;
using CowCalfTracker.Domain.Cattle;

namespace CowCalfTracker.Application.CreateCow
{
    public sealed class CreateCowService(ICowRepository cowRepository)
    {
        public async Task<Cow> CreateCowHandler(string? name, int tagNumber, CancellationToken cancellationToken) {
            var cow = Cow.Create(name, tagNumber);

            var result = await cowRepository.AddAsync(cow, cancellationToken);

            return result;
        }
    }
}
