using FluentValidation;
using N5.Api.Application.Validators.Permissions;

namespace N5.Api.Application.Features.Permissions.Commands.CreatePermission;

public class CreatePermissionCommandValidator : AbstractValidator<CreatePermissionCommand>
{
    public CreatePermissionCommandValidator()
    {
        Include(new UpsertPermissionDTOValidator());
    }
}
