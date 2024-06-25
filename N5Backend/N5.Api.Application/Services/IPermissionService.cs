using N5.Api.Application.DTOs;

namespace N5.Api.Application.Services;

public interface IPermissionService
{
    Task<List<PermissionDTO>> GetPermissions();
}
