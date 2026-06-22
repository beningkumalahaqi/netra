using Microsoft.Extensions.Options;

namespace Netra.Api.Options;

public class DatabaseOptions
{
    public const string SectionName = "Database";

    public string ConnectionString { get; set; } = string.Empty;
    public int RetryCount { get; set; } = 3;
    public int CommandTimeoutSeconds { get; set; } = 30;
}

public class DatabaseOptionsValidator : IValidateOptions<DatabaseOptions>
{
    public ValidateOptionsResult Validate(string? name, DatabaseOptions options)
    {
        if (string.IsNullOrWhiteSpace(options.ConnectionString))
            return ValidateOptionsResult.Fail("Database connection string is required.");

        return ValidateOptionsResult.Success;
    }
}
