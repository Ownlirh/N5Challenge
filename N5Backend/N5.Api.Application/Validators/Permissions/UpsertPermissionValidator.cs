using FluentValidation;
using N5.Api.Application.DTOs;
namespace N5.Api.Application.Validators.Permissions;

public class UpsertPermissionDTOValidator : AbstractValidator<RegisterPermissionDTO>
{
    public UpsertPermissionDTOValidator()
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

        RuleFor((newPermission) => newPermission.PermissionTypeId)
                    .NotEmpty()
                    .NotNull()
                    .GreaterThan(0);
    }
}