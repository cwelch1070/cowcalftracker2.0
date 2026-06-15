using CowCalfTracker.Domain.Cattle;

namespace CowCalfTracker.Application.Cows;

public sealed record CowResponse(Guid Id, string? Name, int TagNumber)
{
    public static CowResponse From(Cow cow)
    {
        return new CowResponse(cow.Id, cow.Name, cow.TagNumber);
    }
}
