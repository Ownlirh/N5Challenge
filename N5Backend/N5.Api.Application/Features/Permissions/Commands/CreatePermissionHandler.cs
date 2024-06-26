using MediatR;
using N5.Api.Application.Services;

namespace N5.Api.Application.Features.Permissions.Commands;

public class CreatePermissionHandler(
    IPermissionService permissionService) : IRequestHandler<CreatePermissionCommand>
{
    public async Task Handle(CreatePermissionCommand request, CancellationToken cancellationToken)
    {
        await permissionService.CreatePermission(request, cancellationToken).ConfigureAwait(false);
    }
}
