# Missing Microsoft.Extensions.Options Namespace

**Date**: 2026-06-23
**Phase**: 0
**Severity**: 🔴 Build error

## Symptom
```
error CS0246: The type or namespace name 'IValidateOptions<>' could not be found
error CS0311: Cannot convert DatabaseOptionsValidator to IValidateOptions<DatabaseOptions>
```

## Root Cause
`Netra.Api` project didn't have a reference to `Microsoft.Extensions.Options` package. The `DatabaseOptionsValidator` implements `IValidateOptions<T>` from that package. The `dotnet new webapi` template only brought in framework references — `IValidateOptions` is in the NuGet package.

## Fix
```
dotnet add src/Netra.Api package Microsoft.Extensions.Options --version 8.0.2
```

## Prevention
When using `IValidateOptions<T>` or `IOptions<T>` for strongly-typed config validation, ensure `Microsoft.Extensions.Options` NuGet package is added to the project.
