using N5.Api.Application.Contracts;
using N5.Api.Application.DTOs;

namespace N5.Api.Application.Services;

public class PermissionService(
    IPermissionsRepository permissionsRepository) : IPermissionService
{
    public Task<List<PermissionDTO>> GetPermissions()
    {
        return permissionsRepository.GetAllPermissionDTO();
    }
}
