# Netra — Agent Guide

**Netra** is a BaaS platform on ASP.NET Core + PostgreSQL. Code lives under `src/`, plans under `.agent/plans/`.

## Project Structure

```
src/
├── Netra.Api/            # Control Plane — admin API, middleware, Program.cs
├── Netra.Gateway/         # Data Plane — dynamic API gateway (Phase 3)
├── Netra.Core/            # Domain models, interfaces, enums, value objects
├── Netra.Infrastructure/  # EF Core DbContext, repos, Hangfire, caching
└── Netra.Worker/          # Background job host (Hangfire worker, Phase 2)
tests/
├── Netra.UnitTests/
└── Netra.IntegrationTests/
```

## Implementation Phases

| Phase | What | Key Deliverable |
|-------|------|----------------|
| 0 | Foundation | Solution, kernel, DB schema, middleware, Docker, tests |
| 1 | Control Plane | Project/Key/Route CRUD, audit, swagger |
| 2 | Provisioning | Hangfire events, DB provisioning, migrations |
| 3 | Gateway | Auth, rate limit, route resolve, dynamic SQL |
| 4 | Observability | Serilog, OTel metrics/tracing, security headers |
| 5 | DevOps | CI/CD, production Docker, docs |

## Agent Workflow

- **@explorer** — fast codebase search before planning work
- **@oracle** — architecture review, code review, tricky debugging
- **@fixer** — bounded implementation (write code per spec)
- **@designer** — UI/UX (not applicable to this backend project)
- **@librarian** — library research for unfamiliar APIs
- **@council** — multi-model consensus for risky decisions

Always read the relevant phase plan in `.agent/plans/` before starting work. Verify with `dotnet build && dotnet test` after changes.
