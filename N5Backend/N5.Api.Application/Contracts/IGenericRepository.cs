namespace Juntoz.Api.Catalog.Application.Contracts;
public interface IGenericRepository<T> where T : class
{
    Task Add(T entity);
    Task AddRange(List<T> entity);
    T Update(T entity);
    void UpdateRange(List<T> entities);
    IQueryable<T> GetQueryable();
    Task<List<T>> GetAllAsync();
    ValueTask<T?> GetByIdAsync(int id);
}
