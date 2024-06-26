using N5.Api.Domain.Entities;

namespace N5.Api.Application.Services;

public interface IPermissionsElasticSearchService : IGenericElasticSearchService<Permission>
{
    Task<Permission> GetDocument(int id, CancellationToken cancellationToken);
}
