using System.Linq.Expressions;

namespace FantasyWeb.DataAccess.Repositories
{
    public interface IRepository<TEntity> where TEntity : class
    {
        Task InsertAsync(TEntity entity);

        Task UpdateAsync(TEntity entity);

        Task DeleteAsync(TEntity entity);

        Task<TEntity> SelectAsync(
            Expression<Func<TEntity, bool>> selector,
            params Expression<Func<TEntity, object>>[] includeProperties);

        Task<IEnumerable<TEntity>> SelectAllAsync();

        Task<IEnumerable<TEntity>> SelectAllAsync(
            Expression<Func<TEntity, bool>> selector,
            params Expression<Func<TEntity, object>>[] includeProperties);

        Task SetNullAsync(TEntity entity, string propertyName);
    }
}
