# Duplicate PackageVersion in Directory.Packages.props

**Date**: 2026-06-23
**Phase**: 0
**Severity**: 🟡 Build warning

## Symptom
```
warning NU1506: Duplicate 'PackageVersion' items found. Remove the duplicate
items or use the Update functionality to ensure a consistent restore behavior.
The duplicate 'PackageVersion' items are: Microsoft.EntityFrameworkCore.InMemory.
```

## Root Cause
`Microsoft.EntityFrameworkCore.InMemory` was added twice to `Directory.Packages.props`:
1. Manually added alongside `Microsoft.AspNetCore.Mvc.Testing`
2. Auto-added by `dotnet add tests/Netra.IntegrationTests package ...`

## Fix
Removed the duplicate entry from `Directory.Packages.props`.

## Prevention
Use `dotnet add package --version X.Y` and check `Directory.Packages.props` afterwards for duplicates. Alternatively, add all packages manually in one well-organized section.
