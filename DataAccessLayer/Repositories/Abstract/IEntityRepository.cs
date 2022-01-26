using BaseCore.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Repositories.Abstract
{
    public interface IEntityRepository<TEntity>
        where TEntity : class, IEntity, new()
        
    {
        /// <summary>
        ///   ToTable
        /// </summary>
        IQueryable<TEntity> Table { get; }

        /// <summary>
        /// To Table as No Tracking
        /// </summary>
        IQueryable<TEntity> AsNoTracking { get; }

        List<TEntity> GetAll(Expression<Func<TEntity, bool>>? filter = null);
        TEntity Get(Expression<Func<TEntity, bool>> filter);
        void Add(TEntity entity);
        void Update(TEntity entity);
        void Delete(TEntity entity);
    }
}
