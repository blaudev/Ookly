using Blau.Configuration;

namespace Ookly.Infrastructure.EntityFramework.InMemory;

public record InMemoryOptions : IOptions
{
    public static string SectionName => "InMemory";

    public string Database { get; init; } = string.Empty;

    public string ConnectionString => $"Data Source={Database}";
}
