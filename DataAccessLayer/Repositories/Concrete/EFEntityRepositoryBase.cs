using BaseCore.Entities.Abstract;
using DataAccessLayer.Contexts.EF;
using DataAccessLayer.Repositories.Abstract;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Repositories.Concrete
{
    public class EFEntityRepositoryBase<TEntity> : IEntityRepository<TEntity>
        where TEntity : class, IEntity, new()
    {
        private readonly GetEduContext _context;
        private readonly DbSet<TEntity> _entities;
        public EFEntityRepositoryBase(GetEduContext context)
        {
            _context = context;
            _entities = _context.Set<TEntity>();
        }

        public IQueryable<TEntity> Table => _entities;

        public IQueryable<TEntity> AsNoTracking => _entities.AsNoTracking();

        public void Add(TEntity entity)
        {
                var addedEntity = _context.Entry(entity);
                addedEntity.State = EntityState.Added;
                _context.SaveChanges();
            
        }


        public void Delete(TEntity entity)
        {
            
                var deletedEntity = _context.Entry(entity);
                deletedEntity.State = EntityState.Deleted;
                _context.SaveChanges();
            
        }
        public TEntity Get(Expression<Func<TEntity, bool>> filter)
        {
            var entity = _entities.FirstOrDefault(filter);
            if(entity != null)
                _context.Entry(entity).State = EntityState.Detached;
            return entity;

        }
        public List<TEntity> GetAll(Expression<Func<TEntity, bool>>? filter = null)
        {
             return filter == null
                                 ? _entities.ToList()
                                 : _entities.Where(filter).ToList();
            
        }
        public void Update(TEntity entity)
        {
            var oldEntity = Get(entity => entity.Id == entity.Id);
            if (oldEntity == null)
                throw new (entity.Id + " id, is not found for " + typeof(TEntity).Name);

            entity.CreatedAt = oldEntity.CreatedAt;
            entity.UpdatedAt = DateTime.Now;

            _context.Update(entity);
            _context.SaveChanges();
        }

    }
}
