FROM mcr.microsoft.com/dotnet/aspnet:10.0 AS runtime
WORKDIR /app
EXPOSE 8080

FROM mcr.microsoft.com/dotnet/sdk:10.0 AS build
WORKDIR /src

COPY src/CowCalfTracker.Api/CowCalfTracker.Api.csproj src/CowCalfTracker.Api/
RUN dotnet restore src/CowCalfTracker.Api/CowCalfTracker.Api.csproj

COPY . .
RUN dotnet publish src/CowCalfTracker.Api/CowCalfTracker.Api.csproj -c Release -o /app/publish

FROM runtime AS final
WORKDIR /app
COPY --from=build /app/publish .

ENV ASPNETCORE_URLS=http://+:8080

ENTRYPOINT ["dotnet", "CowCalfTracker.Api.dll"]