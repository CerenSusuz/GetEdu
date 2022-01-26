using AutoMapper;
using BaseCore.Aspects.Caching;
using BaseCore.Entities.Abstract;
using BaseCore.Utilities.Results.Abstract;
using BaseCore.Utilities.Results.Concrete;
using BusinessLayer.Repositories.Abstract;
using DataAccessLayer.Repositories.Abstract;

namespace BusinessLayer.Repositories.Concrete
{
    public class ServiceRepository<TEntity,TDto> : IServiceRepository<TEntity,TDto>
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

        [CacheRemoveAspect("")]
        public IResult Update(int id, TDto dto)
        {
            var entity = _mapper.Map<TEntity>(dto);
            entity.Id = id;
            _repository.Update(entity);
            return new SuccessResult();
        }

        [CacheAspect]
        public IDataResult<TDto> GetById(int id)
        {
            var entity = _repository.Get(entity => entity.Id == id);
            var dto = _mapper.Map<TDto>(entity);
            return new SuccessDataResult<TDto>(dto);
        }

        [CacheRemoveAspect("")]
        public IResult Delete(int id)
        {
            var entity = _repository.Get(entity => entity.Id == id);
            _repository.Delete(entity);
            return new SuccessResult();
        }

        [CacheRemoveAspect("")]
        public IResult Insert(TDto dto)
        {
            var entity = _mapper.Map<TEntity>(dto);
            _repository.Add(entity);
            return new SuccessResult();
        }


    }
}
