namespace Ookly.Infrastructure.Elastic;

public class ElasticOptions(string scheme, string host, int port, string username, string password, string indexName)
{
    public string Scheme { get; private set; } = scheme;
    public string Host { get; private set; } = host;
    public int Port { get; private set; } = port;
    public string Username { get; private set; } = username;
    public string Password { get; private set; } = password;
    public string IndexName { get; private set; } = indexName;

    public Uri Uri => new($"{Scheme}://{Username}:{Password}@{Host}:{Port}");
}
