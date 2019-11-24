namespace BeerToday.Data.Model
{
    using System.Linq;
    using System.Threading.Tasks;
    using System.Collections.Generic;

    using Results;
    using Entities.Base;

    public interface IRepository<TKey, TEntity> where TEntity : BaseEntity<TKey>
    {
        IQueryable<TEntity> GetQueryable();

        Task<TEntity> FindAsync(TKey key);

        Task<OperationResult<TEntity>> CreateAsync(TEntity entity);

        Task<OperationResult<TEntity>> CreateRangeAsync(IEnumerable<TEntity> entities);

        Task<OperationResult<TEntity>> UpdateAsync(TEntity entity);

        Task<OperationResult<TEntity>> RemoveAsync(TKey key);

        Task<OperationResult<TEntity>> RemoveRangeAsync(IEnumerable<TEntity> entities);
    }
}
