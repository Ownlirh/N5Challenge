using MediatR;
using N5.Api.Application.DTOs;
using N5.Api.Application.Services;

namespace N5.Api.Application.Features.Permissions.Queries;

public class GetPermissionByIdHandler(
    IPermissionService permissionService) : IRequestHandler<GetPermissionByIdQuery, PermissionDTO>
{
    public Task<PermissionDTO> Handle(GetPermissionByIdQuery request, CancellationToken cancellationToken)
    {
        return permissionService.GetPermissionById(request.PermissionId, cancellationToken);
    }
}
