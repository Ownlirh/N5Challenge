using MediatR;
using N5.Api.Application.DTOs;

namespace N5.Api.Application.Features.Permissions.Commands.CreatePermission;

public class CreatePermissionCommand : RegisterPermissionDTO, IRequest
{

}
