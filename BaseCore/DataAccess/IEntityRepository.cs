using BaseCore.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BaseCore.DataAccess.EntityFramework
{
    public interface IEntityRepository<TEntity>
        where TEntity:class, IEntity,new()
    {
        /// <summary>
        ///   ToTable
        /// </summary>
        IQueryable<TEntity> Table();

        /// <summary>
        /// To Table as No Tracking
        /// </summary>
        IQueryable<TEntity> AsNoTracking();

        /// <summary>
        /// Gets the entity that is meets the given filter.
        /// </summary>
        /// <param name="filter"></param>
        /// <returns></returns>
        Task<TEntity> GetAsync(Expression<Func<TEntity, bool>> filter);

        /// <summary>
        /// Inserts the entity to the database.
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        Task InsertAsync(TEntity entity);

        /// <summary>
        /// Updates the given entity.
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        Task UpdateAsync(TEntity entity);

        /// <summary>
        /// Deletes the entity.
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        Task DeleteAsync(TEntity entity);

        /// <summary>
        /// Deletes range of entities.
        /// </summary>
        /// <param name="entities"></param>
        /// <returns></returns>
        Task DeleteRangeAsync(List<TEntity> entities);
    }
}
