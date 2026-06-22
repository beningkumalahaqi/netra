#!/usr/bin/env bash
set -euo pipefail

# Start PostgreSQL only, run the .NET app natively for fast dev-loop
echo "Starting PostgreSQL..."
docker compose up -d postgres

echo "Waiting for PostgreSQL to be healthy..."
until docker compose exec postgres pg_isready -U netra -d netra > /dev/null 2>&1; do
  sleep 1
done

echo "PostgreSQL is ready!"

echo ""
echo "Now run the API locally:"
echo "  dotnet run --project src/Netra.Api"
echo ""
echo "Or with Zed Debugger:"
echo "  Open Debug panel -> 'Netra.Api (local)' -> F5"
echo ""
echo "Health check: http://localhost:5000/health"
