using CowCalfTracker.Api.Endpoints;
using CowCalfTracker.Application.CreateCow;
using CowCalfTracker.Infrastructure;
using CowCalfTracker.Infrastructure.DependencyInjection;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();
builder.Services.AddScoped<CreateCowService>();
builder.Services.AddInfrastructure(builder.Configuration);

var app = builder.Build();

try
  {
      using var scope = app.Services.CreateScope();
      var dbContext = scope.ServiceProvider.GetRequiredService<CowCalfTrackerDbContext>();
      dbContext.Database.Migrate();
  }
  catch (Exception ex)
  {
      app.Logger.LogError(ex, "An error occurred while applying database migrations.");
      throw;
  }

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.MapEndpoints();

app.Run();