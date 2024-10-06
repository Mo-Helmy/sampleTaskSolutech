using System.Linq.Expressions;
using AutoMapper;

namespace Task.Core.Interfaces;

public interface IRepository<TEntity> where TEntity : class, IEntity
{
    IQueryable<TEntity> GetQueryable();
    Task<TEntity> GetByIdAsync(int id, CancellationToken cancellationToken);
    Task<TEntity> GetByIdAsync(Guid id, CancellationToken cancellationToken);
    Task<IEnumerable<TEntity>> GetAllAsync(CancellationToken cancellationToken);
    Task<List<TDto>> GetAllWithMapping<TDto>(IMapper map, CancellationToken cancellationToken,
        Expression<Func<TEntity, bool>>? filter = null,
        Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>>? orderBy = null
    );
    Task<TEntity> Add(TEntity entity, CancellationToken cancellationToken);
    Task<TEntity> Update(TEntity entity, CancellationToken cancellationToken);
    ValueTask Remove(TEntity entity, CancellationToken cancellationToken);
    Task<bool> AnyAsync(Expression<Func<TEntity, bool>> filter, CancellationToken cancellationToken);
    Task<TDto?> FirstOrDefaultAsyncWithMapping<TDto>(CancellationToken cancellationToken,
        IMapper map,
        Expression<Func<TEntity, bool>>? filter = null);
    Task<TEntity?> FirstOrDefaultAsync(CancellationToken cancellationToken,
        Expression<Func<TEntity, bool>>? filter = null,
        Func<IQueryable<TEntity>, IQueryable<TEntity>>? includeProperties = null);
}