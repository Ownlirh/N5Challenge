using MediatR;
using N5.Api.Application.Contracts;
using N5.Api.Application.DTOs;

namespace N5.Api.Application.Features.PermissionTypes.Queries.GetPermissionTypes;

public class GetPermissionTypeHandler(
    IUnitOfWork unitOfWork
    ) : IRequestHandler<GetPermissionTypeQuery, List<PermissionTypesDTO>>
{
    public Task<List<PermissionTypesDTO>> Handle(GetPermissionTypeQuery request, CancellationToken cancellationToken)
    {
        return unitOfWork.PermissionTypeRepository.GetAllPermissionsDTO();
    }
}
