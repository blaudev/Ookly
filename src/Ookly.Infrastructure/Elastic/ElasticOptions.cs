namespace Ookly.Infrastructure.Elastic;

public record ElasticOptions
{
    public string Scheme { get; init; } = default!;
    public string Host { get; init; } = default!;
    public int Port { get; init; }
    public string Username { get; init; } = default!;
    public string Password { get; init; } = default!;
    public string IndexName { get; init; } = default!;

    public Uri Uri => new($"{Scheme}://{Username}:{Password}@{Host}:{Port}");
}
