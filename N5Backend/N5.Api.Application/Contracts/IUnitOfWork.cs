namespace N5.Api.Application.Contracts;

public interface IUnitOfWork
{
    IPermissionTypeRepository PermissionTypeRepository { get; }
    IPermissionsRepository PermissionRepository { get; }
    Task SaveChangesAsync();
    Task BeginTransactionAsync();
    Task CommitAsync();
    Task RollBackAsync();
    ValueTask DisposeAsync();
}
