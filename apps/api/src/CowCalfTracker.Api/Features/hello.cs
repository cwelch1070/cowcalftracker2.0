namespace CowCalfTracker.Api.Features
{
    public static class HelloWorld
    {
        public static IEndpointRouteBuilder HelloEndpoint(IEndpointRouteBuilder app)
        {
            app.MapGet("/hello", () =>
            {
                return Results.Ok("Hello World");
            })
            .WithName("HelloWorldEndpoint");

            return app;
        }
    }
}