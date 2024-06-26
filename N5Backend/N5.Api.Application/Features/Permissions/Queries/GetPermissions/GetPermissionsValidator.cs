using FluentValidation;

namespace N5.Api.Application.Features.Permissions.Queries.GetPermissions;

public class GetPermissionsValidator : AbstractValidator<GetPermissionQuery>
{
    public GetPermissionsValidator()
    {
        RuleFor((permission) => permission.Limit)
            .GreaterThan(0)
            .LessThanOrEqualTo(100);
    }
}
