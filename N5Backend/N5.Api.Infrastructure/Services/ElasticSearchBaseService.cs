using Elastic.Clients.Elasticsearch;
using Elastic.Transport;
using N5.Api.Domain.Models;

namespace N5.Api.Infrastructure.Services;

public abstract class ElasticSearchBaseService
{
    protected readonly ElasticsearchClient _client;
    protected ElasticSearchBaseService(string indexName, AppSettings appSettings)
    {
        ElasticsearchClientSettings settings = new ElasticsearchClientSettings(new Uri(appSettings.ElasticSearch.Uri))
                                                                             .Authentication(new BasicAuthentication(appSettings.ElasticSearch.Username, appSettings.ElasticSearch.Password))
                                                                             .DefaultIndex(indexName.ToString()!);
        _client = new ElasticsearchClient(settings);
    }
}
