using Juntoz.Api.Catalog.Application.Contracts;
using Microsoft.EntityFrameworkCore;

namespace N5.Api.Infrastructure.Repositories;

public class GenericRepository<TContext, T> : IGenericRepository<T> where T : class where TContext : DbContext
{
    private readonly TContext _dbContext;
    private readonly DbSet<T> _dbSet;

    public GenericRepository(TContext dbContext)
    {
        _dbContext = dbContext;
        _dbSet = _dbContext.Set<T>();
    }

    public async Task Add(T entity)
    {
        await _dbSet.AddAsync(entity).ConfigureAwait(false);
    }
    public async Task AddRange(List<T> entities)
    {
        await _dbSet.AddRangeAsync(entities).ConfigureAwait(false);
    }

    public IQueryable<T> GetQueryable()
    {
        return _dbSet.AsQueryable();
    }

    public ValueTask<T?> GetByIdAsync(int id)
    {
        return _dbSet.FindAsync(id);
    }

    public Task<List<T>> GetAllAsync()
    {
        return _dbSet.ToListAsync();
    }

    public T Update(T entity)
    {
        var entry = _dbContext.Entry(entity);

        if (entry.State == EntityState.Detached)
        {
            _dbSet.Attach(entity);
        }

        entry.State = EntityState.Modified;

        return entity;
    }

    public void UpdateRange(List<T> entities)
    {
        _dbSet.UpdateRange(entities);
    }
}
