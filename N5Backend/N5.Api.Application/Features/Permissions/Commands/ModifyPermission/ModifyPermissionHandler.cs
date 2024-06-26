using MediatR;
using N5.Api.Application.Services;

namespace N5.Api.Application.Features.Permissions.Commands.ModifyPermission;

public class ModifyPermissionHandler(
    IPermissionService permissionService) : IRequestHandler<ModifyPermissionCommand>
{
    public Task Handle(ModifyPermissionCommand request, CancellationToken cancellationToken)
    {
        return permissionService.ModifyPermission(request, cancellationToken);
    }
}
