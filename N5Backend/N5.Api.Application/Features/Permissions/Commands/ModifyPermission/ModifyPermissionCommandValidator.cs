using FluentValidation;
using N5.Api.Application.Validators.Permissions;

namespace N5.Api.Application.Features.Permissions.Commands.ModifyPermission;

public class ModifyPermissionCommandValidator : AbstractValidator<ModifyPermissionCommand>
{
    public ModifyPermissionCommandValidator()
    {
        RuleFor((permission) => permission.Id)
                        .NotEmpty()
                        .NotNull()
                        .GreaterThan(0);

        Include(new UpsertPermissionDTOValidator());
    }
}
