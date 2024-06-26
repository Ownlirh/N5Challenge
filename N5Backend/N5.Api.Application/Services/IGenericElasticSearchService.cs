namespace N5.Api.Application.Services;

public interface IGenericElasticSearchService<T> where T : class
{
    Task<bool> AddOrUpdate(T document, CancellationToken cancellationToken);
}
