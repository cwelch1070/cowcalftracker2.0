using CowCalfTracker.Api.Endpoints;
using CowCalfTracker.Application.GetCow;

namespace CowCalfTracker.Api.Features
{
    public class GetCow : IEndpoint
    {
        public void MapEndpoint(IEndpointRouteBuilder app)
        {
            app.MapGet("/cattle/{id:guid}", async (Guid id, GetCowHandler getCowHandler, CancellationToken cancellationToken) =>
            {
                var cow = await getCowHandler.GetByIdAsync(id, cancellationToken);

                return cow is null
                    ? Results.NotFound()
                    : Results.Ok(cow);
            })
            .WithName(nameof(GetCow));
        }
    }
}
