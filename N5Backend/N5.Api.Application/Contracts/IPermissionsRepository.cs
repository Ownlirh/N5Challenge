using Juntoz.Api.Catalog.Application.Contracts;
using N5.Api.Application.DTOs;
using N5.Api.Domain.Entities;

namespace N5.Api.Application.Contracts;

public interface IPermissionsRepository : IGenericRepository<Permission>
{
    [Obsolete("We should use only data from Elastic Search.")]
    Task<List<PermissionDTO>> GetAllPermissionDTO();
}
