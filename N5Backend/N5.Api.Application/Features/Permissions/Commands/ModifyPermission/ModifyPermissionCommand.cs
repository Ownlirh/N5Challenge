using MediatR;
using N5.Api.Application.DTOs;

namespace N5.Api.Application.Features.Permissions.Commands.ModifyPermission;

public class ModifyPermissionCommand : ModifyPermissionDTO, IRequest
{
}
