using Microsoft.EntityFrameworkCore;
using System.Diagnostics.CodeAnalysis;
using System.Linq.Expressions;
using TorcBookSearch.Contracts.Repositories;
using TorcBookSearch.Data;
using TorcBookSearch.Models;

namespace TorcBookSearch.Repositories;

internal abstract class RepositoryBase<TEntity>(TorcBookSearchDbContext context) : IRepository<TEntity>
    where TEntity : Entity
{
    protected TorcBookSearchDbContext Context { get; private set; } = context;


    public virtual Task<int> CountAsync()
    {
        var dbset = Context.Set<TEntity>();

        return dbset.CountAsync();
    }

    public virtual Task<int> CountAsync([NotNull] Expression<Func<TEntity, bool>> predicate)
    {
        var dbset = Context.Set<TEntity>();
        var query = dbset.Where(predicate);

        return query.CountAsync();
    }

    public virtual Task<TEntity[]> GetAllAsync(int page = 0, int take = 0)
    {
        var dbset = Context.Set<TEntity>();
        var query = dbset.AsQueryable();

        if (page > 0 && take > 0)
            query = query.Skip((page - 1) * take).Take(take);

        return query.OrderByDescending(_ => _.Id).ToArrayAsync();
    }

    public virtual Task<TEntity[]> GetAsync([NotNull] Expression<Func<TEntity, bool>> predicate, int page = 0, int take = 0)
    {
        var dbset = Context.Set<TEntity>();
        var query = dbset.Where(predicate);

        if (page > 0 && take > 0)
            query = query.Skip((page - 1) * take).Take(take);

        return query.OrderByDescending(_ => _.Id).ToArrayAsync();
    }
}
