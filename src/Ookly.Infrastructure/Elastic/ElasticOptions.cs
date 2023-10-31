using Blau.Configuration;

namespace Ookly.Infrastructure.Elastic;

public record ElasticOptions : IDatabaseOptions
{
    public static string SectionName => "Elastic";

    public string Scheme { get; init; } = default!;
    public string Host { get; init; } = default!;
    public int Port { get; init; }
    public string Username { get; init; } = default!;
    public string Password { get; init; } = default!;
    public string Index { get; init; } = default!;

    public string ConnectionString => $"{Scheme}://{Username}:{Password}@{Host}:{Port}";
}
