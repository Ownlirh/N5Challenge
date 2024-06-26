using MediatR;
using N5.Api.Application.DTOs;
using N5.Api.Application.Services;

namespace N5.Api.Application.Features.Permissions.Queries.GetPermissions;

public class GetPermissionHandler(
    IPermissionsElasticSearchService permissionsElasticSearchService) : IRequestHandler<GetPermissionQuery, PermissionListDTO>
{
    public Task<PermissionListDTO> Handle(GetPermissionQuery request, CancellationToken cancellationToken)
    {
        return permissionsElasticSearchService.GetPermissions(request.Limit, cancellationToken);
    }
}
