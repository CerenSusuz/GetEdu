using BaseCore.Entities.Abstract;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BaseCore.DataAccess.EntityFramework
{
    public class EFEntityRepositoryBase<TEntity, TContext> : IEntityRepository<TEntity>
        where TEntity : class, IEntity, new()
        where TContext : DbContext, new()
    {

        public async Task DeleteAsync(TEntity entity)
        {
            using(TContext context = new TContext())
            {
                var deletedEntity = context.Entry(entity);
                deletedEntity.State = EntityState.Deleted;
                await context.SaveChangesAsync();
            }
        }

        public async Task DeleteRangeAsync(List<TEntity> entities)
        {
            using (TContext context = new TContext())
            {
                foreach (var entity in entities)
                {
                    var deletedEntity = context.Entry(entity);
                    deletedEntity.State = EntityState.Deleted;
                }
                await context.SaveChangesAsync();
            }
        }


        public async Task<TEntity> GetAsync(Expression<Func<TEntity, bool>> filter)
        {
            using (TContext context = new TContext())
            {
#pragma warning disable CS8603 // Possible null reference return.
                return await context.Set<TEntity>()
                    .FirstOrDefaultAsync(filter);
#pragma warning restore CS8603 // Possible null reference return.
            }

        }

        public async Task InsertAsync(TEntity entity)
        {
            using (TContext context = new TContext())
            {
                entity.CreatedAt = DateTime.Now;
                entity.UpdatedAt = DateTime.Now;

                var addedEntity = context.Entry(entity);
                addedEntity.State = EntityState.Added;

                await context.SaveChangesAsync();
            }
        }

        public async Task UpdateAsync(TEntity entity)
        {
            using (TContext context = new TContext())
            {
                var oldEntity = await GetAsync(x=>x.Id == entity.Id);

                entity.CreatedAt = oldEntity.CreatedAt;
                entity.UpdatedAt = DateTime.Now;

                var updatedEntity = context.Entry(entity);
                updatedEntity.State = EntityState.Modified;

                await context.SaveChangesAsync();
            }
        }
    }
}
