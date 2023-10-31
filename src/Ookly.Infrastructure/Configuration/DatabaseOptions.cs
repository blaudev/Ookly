namespace Ookly.Infrastructure.Configuration;

public enum DatabaseType
{
    InMemory,
    Postgres
}

public record DatabaseOptions
{
    public static readonly string SectionName = "Database";

    public DatabaseType DatabaseType { get; init; }
    public string ConnectionPattern { get; init; } = string.Empty;
    public string Host { get; init; } = string.Empty;
    public int Port { get; init; }
    public string Database { get; set; } = string.Empty;
    public string Username { get; init; } = string.Empty;
    public string Password { get; init; } = string.Empty;
    public bool Truncate { get; init; }
    public bool Seed { get; init; }
}
