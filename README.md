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

### Option A: Full Docker (easiest)

```bash
docker compose up
curl localhost:5000/health
```

### Option B: PostgreSQL in Docker, API locally (recommended for dev)

```bash
# Start only PostgreSQL
docker compose up -d postgres

# Run the API with hot reload
dotnet run --project src/Netra.Api
# Health check: http://localhost:5000/health
```

Or use the shortcut:

```bash
chmod +x scripts/dev.sh
./scripts/dev.sh
```

### Debugging (Zed)

1. Install the .NET extension in Zed (it provides `netcoredbg` adapter)
2. Start PostgreSQL: `docker compose up -d postgres`
3. In Zed, open the Debug panel and select **"Netra.Api (local)"**
4. Press F5 — Zed builds then attaches the debugger
5. Set breakpoints, inspect variables, step through code

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

## Development

```bash
# Run tests
dotnet test

# Build
dotnet build

# Start DB + API locally
docker compose up -d postgres
dotnet run --project src/Netra.Api
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
