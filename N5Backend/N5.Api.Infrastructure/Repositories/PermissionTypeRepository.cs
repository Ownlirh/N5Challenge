using N5.Api.Application.Contracts;
using N5.Api.Domain.Entities;
using N5.Api.Infrastructure.Context;

namespace N5.Api.Infrastructure.Repositories;

public class PermissionTypeRepository(N5Context dbContext) : GenericRepository<N5Context, PermissionType>(dbContext), IPermissionTypeRepository
{
}
