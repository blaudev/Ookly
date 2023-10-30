namespace Ookly.Web.Configuration;

public record DataOptions
{
    public bool Truncate { get; init; }
    public bool Seed { get; init; }
}
