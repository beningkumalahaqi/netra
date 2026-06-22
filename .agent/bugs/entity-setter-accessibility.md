# Entity Setter Accessibility

**Date**: 2026-06-23
**Phase**: 0
**Severity**: 🔴 Build error

## Symptom
```
error CS0272: The property or indexer 'Entity<Guid>.UpdatedAt' cannot be used
in this context because the set accessor is inaccessible
```

## Root Cause
`Entity<TId>.UpdatedAt` had `protected set`, but `NetraDbContext.SaveChangesAsync()` override needed to set it on `EntityState.Modified` entries from outside the class hierarchy.

## Fix
Changed `UpdatedAt { get; protected set; }` to `UpdatedAt { get; set; }`.

Also applied the same to `Id` property after test code hit the same error when constructing entities with explicit IDs.

## Prevention
For EF Core entities that need timestamp tracking in the DbContext interceptor/save-changes override, the `UpdatedAt` property must have a public setter.
