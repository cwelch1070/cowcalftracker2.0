using CowCalfTracker.Api.Endpoints;
using CowCalfTracker.Application.abstractions;
using CowCalfTracker.Application.CreateCow;
using Microsoft.AspNetCore.Mvc;

namespace CowCalfTracker.Api.Features
{
    public class CreateCow : IEndpoint
    {
        public void MapEndpoint(IEndpointRouteBuilder app)
        {
            app.MapPost("/cattle", async ([FromBody]Request request, CreateCowService createCowService, CancellationToken cancellationToken) =>
            {
                var result = await createCowService
                    .CreateCowHandler(
                        request.Name, 
                        request.TagNumber,
                        cancellationToken
                    );

                return Results.Ok(result);
            })
            .WithName(nameof(CreateCow));
        }

        private record Request(string? Name, int TagNumber);
    }

    public class HealthCheck : IEndpoint
    {
        public void MapEndpoint(IEndpointRouteBuilder app)
        {
            app.MapGet("/", async (CancellationToken cancelationToken) => {
                return Results.Ok("API is up and running.");
            })
            .WithName(nameof(HealthCheck));
        }
    }
}