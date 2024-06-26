using MediatR;
using N5.Api.Application.DTOs;

namespace N5.Api.Application.Features.PermissionTypes.Queries.GetPermissionTypes;

public class GetPermissionTypeQuery : IRequest<List<PermissionTypesDTO>>
{
}
