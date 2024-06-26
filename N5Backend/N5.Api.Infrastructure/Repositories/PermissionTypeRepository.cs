using Microsoft.EntityFrameworkCore;
using N5.Api.Application.Contracts;
using N5.Api.Application.DTOs;
using N5.Api.Domain.Entities;
using N5.Api.Infrastructure.Context;

namespace N5.Api.Infrastructure.Repositories;

public class PermissionTypeRepository(N5Context dbContext) : GenericRepository<N5Context, PermissionType>(dbContext), IPermissionTypeRepository
{
    public Task<List<PermissionTypesDTO>> GetAllPermissionsDTO()
    {
        return dbContext.PermissionTypes
                .Select((permissionType) => new PermissionTypesDTO()
                {
                    Id = permissionType.Id,
                    Description = permissionType.Description,
                }).ToListAsync();
    }
}
