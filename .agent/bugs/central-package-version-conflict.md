# Central Package Version Conflict

**Date**: 2026-06-23
**Phase**: 0
**Severity**: 🔴 Blocked build

## Symptom
```
error NU1008: Projects that use central package version management should not
define the version on the PackageReference items but on the PackageVersion items:
coverlet.collector;Microsoft.NET.Test.Sdk;xunit;xunit.runner.visualstudio.
```

## Root Cause
`Directory.Packages.props` defined `<ManagePackageVersionsCentrally>true</ManagePackageVersionsCentrally>` but the test projects (`Netra.UnitTests`, `Netra.IntegrationTests`) still had inline `Version` attributes on their `PackageReference` items from the `dotnet new xunit` template.

## Fix
1. Added `PackageVersion` entries in `Directory.Packages.props` for all test packages
2. Removed `Version` attributes from `<PackageReference>` in both test `.csproj` files
3. Added `Microsoft.AspNetCore.Mvc.Testing` and `Microsoft.EntityFrameworkCore.InMemory` to central management

## Prevention
Always remove `Version` from `PackageReference` in any project when central package management is enabled. Add new package versions to `Directory.Packages.props` instead.
