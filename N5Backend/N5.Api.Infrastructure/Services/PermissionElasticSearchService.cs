using N5.Api.Application.DTOs;
using N5.Api.Application.Exceptions;
using N5.Api.Application.Services;
using N5.Api.Domain.Models;
using N5.Api.Domain.Models.Structs;

namespace N5.Api.Infrastructure.Services;

public class PermissionElasticSearchService : ElasticSearchBaseService, IPermissionsElasticSearchService
{
    public PermissionElasticSearchService(AppSettings appSettings) : base(ElasticSearchIndexes.Permissions, appSettings)
    {
    }
    public async Task<bool> AddOrUpdate(PermissionDTO document, CancellationToken cancellationToken = default)
    {
        var indexResponse = await _client.IndexAsync(document, cancellationToken);
        return indexResponse.IsValidResponse;
    }

    public async Task<PermissionDTO> GetDocument(int id, CancellationToken cancellationToken = default)
    {
        var response = await _client.GetAsync<PermissionDTO>(id, cancellationToken);

        if (response.IsValidResponse && response.Source != null)
        {
            return response.Source;
        }

        throw new BusinessException($"Failed to get document with id {id}");
    }
}
