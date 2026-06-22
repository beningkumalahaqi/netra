# Port 5432 Conflict — Stale PostgreSQL Container

**Date**: 2026-06-23
**Phase**: 0
**Severity**: 🟠 Blocked Docker startup

## Symptom
```
Error response from daemon: Bind for 0.0.0.0:5432 failed: port is already allocated
```

## Root Cause
A PostgreSQL container (`kelola-in-db`) from another project (Kelola-In) was already running on port 5432. This persisted across multiple Colima restarts. Killing SSH mux processes repeatedly broke the Colima Docker socket, requiring full `colima stop/start` cycles.

## Troubleshooting Path
1. `lsof -i :5432` showed `ssh` process holding the port — initially misidentified as Colima SSH mux
2. `docker ps` eventually revealed the actual `kelola-in-db` container
3. `docker stop kelola-in-db && docker rm kelola-in-db` freed the port

## Fix
```
docker stop kelola-in-db kelola-in-adminer
docker rm kelola-in-db kelola-in-adminer
```

## Lesson
Always check `docker ps` first when diagnosing port conflicts. Don't assume SSH mux is the culprit until you've ruled out running containers. The Colima SSH mux shows up in `lsof` but only forwards the guest port — the actual binding is the container port mapping.
