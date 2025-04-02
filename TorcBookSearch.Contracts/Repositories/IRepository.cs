using System.Diagnostics.CodeAnalysis;
using System.Linq.Expressions;

namespace TorcBookSearch.Contracts.Repositories;

public interface IRepository<TEntity> 
    where TEntity : class
{
    Task<int> CountAsync();
    Task<int> CountAsync([NotNull] Expression<Func<TEntity, bool>> predicate);

    Task<TEntity[]> GetAllAsync(int page = 0, int take = 0);
    Task<TEntity[]> GetAsync([NotNull] Expression<Func<TEntity, bool>> predicate, int page = 0, int take = 0);
}
