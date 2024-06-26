using N5.Api.Application.Contracts;
using N5.Api.Application.DTOs;
using N5.Api.Domain.Entities;
using System.Text.Json;

namespace N5.Api.Application.Services;

public class PermissionService(
    IUnitOfWork unitOfWork,
    IPermissionsElasticSearchService permissionsElasticSearchService) : IPermissionService
{
    public async Task CreatePermission(RegisterPermissionDTO request, CancellationToken cancellationToken)
    {
        try
        {
            await unitOfWork.BeginTransactionAsync();

            var newPermission = new Permission()
            {
                Name = request.Name,
                Surname = request.Surname,
                PermissionId = request.PermissionId,
            };

            await unitOfWork.PermissionRepository.Add(newPermission).ConfigureAwait(false);
            await unitOfWork.SaveChangesAsync().ConfigureAwait(false);

            var permissionAdded = await permissionsElasticSearchService.AddOrUpdate(newPermission, cancellationToken).ConfigureAwait(false);

            if (!permissionAdded)
            {
                // TODO: Log
                throw new Exception($"There was an error while trying to add permission to Elastic Search, Request -> {JsonSerializer.Serialize(request)}");
            }

            await unitOfWork.CommitAsync().ConfigureAwait(false);

        }
        catch (Exception)
        {
            await unitOfWork.RollBackAsync().ConfigureAwait(false);
            throw;
        }
        finally
        {
            await unitOfWork.DisposeAsync().ConfigureAwait(false);
        }
    }

    public Task<List<PermissionDTO>> GetPermissions()
    {
        // TODO: Change to elastic search
        return unitOfWork.PermissionRepository.GetAllPermissionDTO();
    }
}
