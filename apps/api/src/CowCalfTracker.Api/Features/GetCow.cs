using CowCalfTracker.Api.Endpoints;
using CowCalfTracker.Application.abstractions;

namespace CowCalfTracker.Api.Features
{
    public class GetCow : IEndpoint
    {
        public void MapEndpoint(IEndpointRouteBuilder app)
        {
            app.MapGet("/cattle/{id:guid}", async (Guid id, ICowRepository cowRepository, CancellationToken cancellationToken) =>
            {
                var cow = await cowRepository.GetByIdAsync(id, cancellationToken);

                return cow is null
                    ? Results.NotFound()
                    : Results.Ok(cow);
            })
            .WithName(nameof(GetCow));
        }
    }
}
