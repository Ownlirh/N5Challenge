using FluentValidation;

namespace N5.Api.Application.Features.Permissions.Commands;

public class CreatePermissionCommandValidator : AbstractValidator<CreatePermissionCommand>
{
    public CreatePermissionCommandValidator()
    {
        RuleFor((newPermission) => newPermission.Name)
                    .NotEmpty()
                    .NotNull()
                    .MaximumLength(250)
                    .MinimumLength(1);

        RuleFor((newPermission) => newPermission.Surname)
                    .NotEmpty()
                    .NotNull()
                    .MaximumLength(250)
                    .MinimumLength(1);

        RuleFor((newPermission) => newPermission.PermissionId)
                    .NotEmpty()
                    .NotNull()
                    .GreaterThan(0);
    }
}
