using CowCalfTracker.Api.Endpoints;
using CowCalfTracker.Application.CreateCow;
using Microsoft.AspNetCore.Mvc;

namespace CowCalfTracker.Api.Features
{
    public class CreateCow : IEndpoint
    {
        public void MapEndpoint(IEndpointRouteBuilder app)
        {
            app.MapPost("/cattle", async ([FromBody]Request request, CancellationToken cancellationToken) =>
            {
                var result = await CreateCowService
                    .CreateCowHandler(
                        request.Name, 
                        request.TagNumber
                    );

                return Results.Ok(result);
            })
            .WithName(nameof(CreateCow));
        }

        private record Request(string? Name, int TagNumber);
    }
}