using N5.Api.Application.Contracts;
using N5.Api.Infrastructure.Context;

namespace N5.Api.Infrastructure.Repositories;

public class UnitOfWork(
    N5Context n5Context,
    IPermissionsRepository permissionRepository,
    IPermissionTypeRepository permissionTypeRepository
    ) : IUnitOfWork
{
    private UnitOfWorkTransaction? _currentTransaction;

    public IPermissionTypeRepository PermissionTypeRepository => permissionTypeRepository;
    public IPermissionsRepository PermissionRepository => permissionRepository;

    public async Task CommitAsync()
    {
        if (_currentTransaction == null)
        {
            throw new InvalidOperationException("No transaction to commit.");
        }

        await _currentTransaction.CommitAsync().ConfigureAwait(false);
        await DisposeAsync().ConfigureAwait(false);
    }

    public async Task RollBackAsync()
    {
        if (_currentTransaction != null)
        {
            await _currentTransaction.RollbackAsync().ConfigureAwait(false);
            _currentTransaction = null;
        }
    }

    public async ValueTask DisposeAsync()
    {
        if (_currentTransaction != null)
        {
            await _currentTransaction.DisposeAsync().ConfigureAwait(false);
            _currentTransaction = null;
        }
    }

    public async Task SaveChangesAsync()
    {
        await n5Context.SaveChangesAsync().ConfigureAwait(false);
    }

    public async Task BeginTransactionAsync()
    {
        if (_currentTransaction != null)
        {
            throw new InvalidOperationException("There is already a transaction in progress.");
        }

        var transaction = await n5Context.Database.BeginTransactionAsync().ConfigureAwait(false);
        _currentTransaction = new UnitOfWorkTransaction(transaction);
    }
}
