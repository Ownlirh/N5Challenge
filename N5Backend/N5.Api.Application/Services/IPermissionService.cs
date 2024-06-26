using N5.Api.Application.DTOs;

namespace N5.Api.Application.Services;

public interface IPermissionService
{
    Task<PermissionDTO> GetPermissionById(int permissionId, CancellationToken cancellationToken);
    Task CreatePermission(RegisterPermissionDTO request, CancellationToken cancellationToken);
    Task ModifyPermission(ModifyPermissionDTO request, CancellationToken cancellationToken);
}
