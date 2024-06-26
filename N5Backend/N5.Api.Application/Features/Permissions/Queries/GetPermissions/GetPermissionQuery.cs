using MediatR;
using N5.Api.Application.DTOs;

namespace N5.Api.Application.Features.Permissions.Queries.GetPermissions;

public class GetPermissionQuery : IRequest<PermissionListDTO>
{
    public int Limit { get; set; } = 5;
}
