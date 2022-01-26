using AutoMapper;
using BaseCore.Aspects.Caching;
using BaseCore.Entities.Abstract;
using BaseCore.Utilities.Results.Abstract;
using BaseCore.Utilities.Results.Concrete;
using BusinessLayer.Repositories.Abstract;
using DataAccessLayer.Repositories.Abstract;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Repositories.Concrete
{
    public class PairingServiceRepository<TEntity, TDto> : IPairingServiceRepository<TEntity,TDto>
        where TEntity : class, IEntity, new()
        where TDto : class, IDto, new()
    {
        private readonly IEntityRepository<TEntity> _repository;
        private readonly IMapper _mapper;

        public PairingServiceRepository(IEntityRepository<TEntity> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
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
            var entity = _repository.Get(entity=>entity.Id == id);
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
