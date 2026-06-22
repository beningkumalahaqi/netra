namespace Netra.Core.Results;

public sealed record Error(string Code, string Message)
{
    public static readonly Error None = new(string.Empty, string.Empty);

    public static Error NotFound(string entity) => new("NOT_FOUND", $"{entity} not found.");
    public static Error Validation(string message) => new("VALIDATION_ERROR", message);
    public static Error Conflict(string message) => new("CONFLICT", message);
    public static Error Unexpected(string message = "An unexpected error occurred.") => new("UNEXPECTED", message);
}
