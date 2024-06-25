using Microsoft.EntityFrameworkCore;
using N5.Api.Application.Contracts;
using N5.Api.Application.DTOs;
using N5.Api.Domain.Entities;
using N5.Api.Infrastructure.Context;

namespace N5.Api.Infrastructure.Repositories;

public class PermissionRepository(N5Context dbContext) : GenericRepository<N5Context, Permission>(dbContext), IPermissionsRepository
{
    public Task<List<PermissionDTO>> GetAllPermissionDTO()
    {
        return dbContext.Permissions.Include((permission) => permission.PermissionType)
                                    .Select((permission) => new PermissionDTO()
                                    {
                                        Id = permission.Id,
                                        Name = permission.Name,
                                        Surname = permission.Surname,
                                        CreatedAt = permission.CreatedAt,
                                        PermissionType = permission.PermissionType.Description,
                                        PermissionId = permission.PermissionType.Id,
                                    }).ToListAsync();
    }
}
