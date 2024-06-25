using Microsoft.EntityFrameworkCore.Storage;

namespace N5.Api.Infrastructure.Repositories;
internal sealed class UnitOfWorkTransaction(IDbContextTransaction transaction) : IAsyncDisposable
{
    private bool _committed;

    public async Task CommitAsync()
    {
        await transaction.CommitAsync().ConfigureAwait(false);
        _committed = true;
    }

    public async Task RollbackAsync()
    {
        if (!_committed && transaction != null)
        {
            await transaction.RollbackAsync().ConfigureAwait(false);
        }
    }

    public async ValueTask DisposeAsync()
    {
        if (!_committed)
        {
            await RollbackAsync().ConfigureAwait(false);
        }

        if (transaction != null)
        {
            await transaction.DisposeAsync().ConfigureAwait(false);
        }
    }
}
