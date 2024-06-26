using MediatR;
using N5.Api.Application.DTOs;

namespace N5.Api.Application.Features.Permissions.Commands;

public class CreatePermissionCommand : RegisterPermissionDTO, IRequest
{

}
