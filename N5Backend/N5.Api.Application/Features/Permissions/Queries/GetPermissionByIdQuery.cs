using MediatR;
using N5.Api.Application.DTOs;

namespace N5.Api.Application.Features.Permissions.Queries;

public class GetPermissionByIdQuery : IRequest<PermissionDTO>
{
    public int PermissionId { get; set; }
}
