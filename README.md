# Netra

**Backend-as-a-Service Platform** — provision production-ready backends in minutes without writing server-side code.

Built on ASP.NET Core 8 + PostgreSQL.

## Architecture

```
Client                 Admin Dashboard
   │                        │
   ▼                        ▼
API Gateway ────────── Control Plane API
(Auth, Rate Limit,     (Project/Key/Route CRUD,
 Route Resolve,         Audit, Migrations)
 Query Execute)               │
   │                    Provisioning Worker
   ▼                        │
Project DBs ────────── Platform DB
```

- **Control Plane** — project management, API key management, route management, provisioning orchestration, audit logging
- **Data Plane** — dynamic API gateway with auth, rate limiting, route resolution, and on-the-fly SQL query execution
- **Tenant Isolation** — dedicated PostgreSQL database per project

## Quick Start

```bash
docker compose up
curl localhost:5000/health
```

## Project Structure

```
src/
├── Netra.Api/            # Control Plane — admin API
├── Netra.Gateway/        # Data Plane — dynamic API gateway
├── Netra.Core/           # Domain models, interfaces, enums
├── Netra.Infrastructure/ # EF Core, repositories, Hangfire
└── Netra.Worker/         # Background jobs (Hangfire)
tests/
├── Netra.UnitTests/
└── Netra.IntegrationTests/
```

## Roadmap

| Phase | What |
|-------|------|
| 0 | Foundation: solution, kernel, DB schema, middleware, Docker, tests |
| 1 | Control Plane: Project/Key/Route CRUD, audit, swagger |
| 2 | Provisioning: Hangfire events, database provisioning, migrations |
| 3 | Gateway: auth, rate limit, route resolve, dynamic SQL |
| 4 | Observability: Serilog, OpenTelemetry, security headers |
| 5 | DevOps: CI/CD, production Docker, docs |
