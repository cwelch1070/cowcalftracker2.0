using CowCalfTracker.Domain.Cattle;

namespace CowCalfTracker.Application.CreateCow
{
    public class CreateCowService()
    {
        public static async Task<Cow> CreateCowHandler(string? name, int tagNumber) {
            var cow = Cow.Create(name, tagNumber);

            return cow;
        }
    }
}
