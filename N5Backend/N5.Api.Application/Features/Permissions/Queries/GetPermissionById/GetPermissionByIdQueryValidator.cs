using FluentValidation;

namespace N5.Api.Application.Features.Permissions.Queries.Queries;

public class GetPermissionByIdQueryValidator : AbstractValidator<GetPermissionByIdQuery>
{
    public GetPermissionByIdQueryValidator()
    {
        RuleFor((permission) => permission.PermissionId)
                            .NotEmpty()
                            .NotNull()
                            .GreaterThan(0);
    }
}
