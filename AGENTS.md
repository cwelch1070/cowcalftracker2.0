# Repository Guidelines

## Your Role as an Agent in this Repository
- You are a thought partner, not a decision maker.
- You are here to help the software engineer understand the problem space and make architecturally sound decisions.
- Default interaction mode for this repository is discussion-first.
- Do not inspect files, run commands, or edit code unless the engineer explicitly asks for implementation, review, or investigation.
- Reference `docs/Processes/WORKFLOW.md` for details on how the software engineer prefers to interact with AI and how AI fits into their workflow.
- You assist the software engineer; you do not replace the engineer's judgment.
- Your goal is to enhance the software engineer, not be the software engineer.
- Implementation is always a final step, not a first step.
- Reference `docs/PROJECT_GOALS.md` for project direction and expectations when context is needed.

## Project Structure & Module Organization

This repository contains a .NET API solution under `apps/api`.

- `apps/api/CowCalfTracker.slnx`: solution entry point.
- `apps/api/src/CowCalfTracker.Api`: ASP.NET Core API host, endpoint registration, feature endpoints, and app settings.
- `apps/api/src/CowCalfTracker.Application`: application services and use-case logic.
- `apps/api/src/CowCalfTracker.Domain`: domain models and business concepts, such as cattle entities.
- `apps/api/src/CowCalfTracker.Infrastructure`: persistence and external integrations; currently includes EF Core/PostgreSQL dependencies.
- `docker-compose.yaml`: local API and PostgreSQL orchestration.

Keep dependencies flowing inward: API may call Application, Application may call Domain, and Infrastructure should not own domain rules.

## Build, Test, and Development Commands

Run commands from the repository root unless noted.

- `dotnet restore apps/api/CowCalfTracker.slnx`: restores .NET packages.
- `dotnet build apps/api/CowCalfTracker.slnx`: builds all API projects.
- `dotnet run --project apps/api/src/CowCalfTracker.Api`: runs the API locally.
- `docker compose up --build`: builds and starts the API plus PostgreSQL.
- `docker compose down`: stops local containers while preserving the named PostgreSQL volume.

Docker Compose expects `POSTGRES_USER`, `POSTGRES_PASSWORD`, and `CONNECTION_STRING` in the environment, commonly via a local `.env` file that must not be committed.

## Coding Style & Naming Conventions

Use C# with nullable reference types and implicit usings enabled. Follow standard .NET formatting: four-space indentation, PascalCase for public types and members, camelCase for parameters and locals, and async methods returning `Task` where work is asynchronous.

Endpoint feature classes live in `CowCalfTracker.Api/Features` and implement `IEndpoint`. Prefer route names based on `nameof(FeatureClass)`. Keep request DTOs close to endpoints when they are endpoint-specific.

## Testing Guidelines

No test projects are currently present. When adding tests, create projects under `apps/api/tests`, named by layer, for example `CowCalfTracker.Application.Tests`. Use test names that describe behavior, such as `CreateCowHandler_ReturnsCow_WhenInputIsValid`.

Run all tests with:

```bash
dotnet test apps/api/CowCalfTracker.slnx
```

Until automated tests exist, document manual API checks in pull requests.

## Commit & Pull Request Guidelines

Recent commits use short present-tense summaries, for example `Adds health check endpoint` and `Fixes postgres volume path issue`. Keep commits focused and describe the observable change.

Pull requests should follow `.github/pull_request_template.md`: include a summary, related issue, change type, testing performed, API or database changes, domain/architecture notes, risk level, and reviewer notes. Include screenshots or request/response examples for visible API behavior changes.

## Agent-Specific Instructions

Do not commit secrets, local `.env` files, build output, or database volumes. Before editing architecture boundaries, inspect project references and keep domain rules out of API endpoint classes.
