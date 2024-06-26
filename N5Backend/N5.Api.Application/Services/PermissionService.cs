using N5.Api.Application.Contracts;
using N5.Api.Application.DTOs;
using N5.Api.Application.Exceptions;
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
                PermissionId = request.PermissionTypeId,
            };

            await unitOfWork.PermissionRepository.Add(newPermission).ConfigureAwait(false);
            await unitOfWork.SaveChangesAsync().ConfigureAwait(false);

            var permissionType = await unitOfWork.PermissionTypeRepository.GetByIdAsync(request.PermissionTypeId).ConfigureAwait(false);

            var newPermissionDTO = new PermissionDTO()
            {
                Id = newPermission.Id,
                Name = newPermission.Name,
                Surname = newPermission.Surname,
                CreatedAt = newPermission.CreatedAt,
                PermissionType = permissionType!.Description,
                PermissionId = permissionType.Id,
            };

            var permissionAdded = await permissionsElasticSearchService.AddOrUpdate(newPermissionDTO, cancellationToken).ConfigureAwait(false);

            if (!permissionAdded)
            {
                // TODO: Log
                throw new Exception($"There was an error while trying to add permission to Elastic Search, Request -> {JsonSerializer.Serialize(request)}");
            }

            await unitOfWork.CommitAsync();
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

    public Task<PermissionDTO> GetPermissionById(int permissionId, CancellationToken cancellationToken)
    {
        return permissionsElasticSearchService.GetDocument(permissionId, cancellationToken);
    }

    public async Task ModifyPermission(ModifyPermissionDTO request, CancellationToken cancellationToken)
    {
        try
        {
            await unitOfWork.BeginTransactionAsync();

            /* 
             * Lo lamento por esta llamada.
             * En este punto no estoy seguro si el challenge pide que todo se haga en Elastic Search
             * O si todo se debe hacer en base de datos y luego sincronizar con elastic search
             * Voy a tomar la segunda idea. Primera vez que veo Elastic Search
             */
            var existingPermission = await unitOfWork.PermissionRepository.GetByIdAsync(request.Id).ConfigureAwait(false);
            var permissionType = await unitOfWork.PermissionTypeRepository.GetByIdAsync(request.PermissionTypeId).ConfigureAwait(false);

            if (existingPermission is null)
            {
                throw new BusinessException($"Permission with Id - {request.PermissionTypeId} not found.");
            }

            existingPermission.Surname = request.Surname;
            existingPermission.Name = request.Name;
            existingPermission.PermissionId = request.PermissionTypeId;

            unitOfWork.PermissionRepository.Update(existingPermission);
            await unitOfWork.SaveChangesAsync().ConfigureAwait(false);

            var newPermissionES = new PermissionDTO()
            {
                Id = existingPermission.Id,
                Name = existingPermission.Name,
                Surname = existingPermission.Surname,
                CreatedAt = existingPermission.CreatedAt,
                PermissionId = existingPermission.PermissionId,
                PermissionType = permissionType.Description
            };

            var permissionAdded = await permissionsElasticSearchService.AddOrUpdate(newPermissionES, cancellationToken).ConfigureAwait(false);

            if (!permissionAdded)
            {
                // TODO: Log
                throw new Exception($"There was an error while trying to add permission to Elastic Search, Request -> {JsonSerializer.Serialize(request)}");
            }

            await unitOfWork.CommitAsync();
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
}
