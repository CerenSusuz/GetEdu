using AutoMapper;
using BaseCore.Aspects.Caching;
using BaseCore.DataAccess.EntityFramework;
using BaseCore.Entities.Abstract;
using BusinessLayer.Repositories.Abstract;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Repositories.Concrete
{
    public class ServiceRepository<TEntity,TDto> : IServiceRepository<TDto>
        where TEntity : class,IEntity,new()
        where TDto : class,IDto,new()
    {
        private readonly IEntityRepository<TEntity> _repository;
        private readonly IMapper _mapper;

        public ServiceRepository(IEntityRepository<TEntity> repository, IMapper mapper)
        {
            _repository = repository;   
            _mapper = mapper;   
        }

        [CacheAspect]
        public virtual async Task<TDto> GetAsync(int id)
        {
            var entity = await _repository.GetAsync(entity => entity.Id == id);
            return _mapper.Map<TDto>(entity);
        }

        public virtual async Task<TDto> GetAllAsync(int id)
        {
            var entity = _repository.GetAllAsync(entity => entity.Id == id);
            return _mapper.Map<TDto>(entity);
        }

        [CacheRemoveAspect]
        public virtual async Task<int> InsertAsync(TDto dto)
        {
            var entity = _mapper.Map<TEntity>(dto);
            await _repository.InsertAsync(entity);
            return entity.Id;
        }

        [CacheRemoveAspect]
        public virtual async Task UpdateAsync(int id, TDto dto)
        {
            var entity = _mapper.Map<TEntity>(dto);
            entity.Id = id;
            await _repository.UpdateAsync(entity);
        }

        [CacheRemoveAspect]
        public virtual async Task DeleteAsync(int id)
        {
            var entity = await _repository.GetAsync(entity=>entity.Id == id);
            await _repository.DeleteAsync(entity);
        }

        [CacheRemoveAspect]
        public virtual async Task DeleteRangeAsync(List<int> listOfId)
        {
            var entities = await _repository.AsNoTracking().Where(x => listOfId.Contains(x.Id)).ToListAsync();

            await _repository.DeleteRangeAsync(entities);
        }

        [CacheRemoveAspect]
        public virtual async Task RemoveCacheAsync()
        {
            await Task.CompletedTask.ConfigureAwait(false);
        }

     
    }
}
