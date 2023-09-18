using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace FantasyWeb.DataAccess.Extensions
{
    public static class DbSetExtensions
    {
        public static IQueryable<TEntity> GetValueWithInclude<TEntity>(this DbSet<TEntity> entitiesDataSet, params Expression<Func<TEntity, object>>[] includeProperties) where TEntity : class
        {
            IQueryable<TEntity> querriedEntities = entitiesDataSet.AsNoTracking();

            return includeProperties.Aggregate(
                querriedEntities,
                (current, includeProperty) => current.Include(includeProperty));
        }
    }
}
