namespace N5.Api.Domain.Models;

public class AppSettings
{
    public required ElasticSearch ElasticSearch { get; init; }
}
public class ElasticSearch
{
    public required string ApiKey { get; init; }
    public required string Uri { get; init; }
    public required string Username { get; init; }
    public required string Password { get; init; }
}
