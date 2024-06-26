using N5.Api.Application.DTOs;

namespace N5.Api.Application.Services;

public interface IPermissionsElasticSearchService : IGenericElasticSearchService<PermissionDTO>
{
    Task<PermissionDTO> GetDocument(int id, CancellationToken cancellationToken);
    Task<PermissionListDTO> GetPermissions(int limit, CancellationToken cancellationToken);
}
