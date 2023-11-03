using Blau.Configuration;

namespace Ookly.Infrastructure.EntityFramework.Postgres;

public record PostgresOptions : IDatabaseOptions
{
    public static string SectionName => "Postgres";

    public string Host { get; init; } = string.Empty;
    public int Port { get; init; }
    public string Database { get; init; } = string.Empty;
    public string Username { get; init; } = string.Empty;
    public string Password { get; init; } = string.Empty;

    public string ConnectionString => $"Host={Host};Port={Port};Database={Database};Username={Username};Password={Password};SSL Mode=Prefer;Trust Server Certificate=true";
}
