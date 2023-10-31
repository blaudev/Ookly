using Blau.Configuration;

namespace Ookly.Infrastructure.Options;

public enum DatabaseType
{
    InMemory,
    Postgres
}

public record DatabaseOptions : IOptions
{
    public static string SectionName => "Database";

    public DatabaseType DatabaseType { get; init; }
    public bool Truncate { get; init; }
    public bool Seed { get; init; }
}
