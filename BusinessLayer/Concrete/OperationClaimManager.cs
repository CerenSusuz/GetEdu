using AutoMapper;
using BaseCore.Aspects.Caching;
using BaseCore.Entities.Concrete;
using BaseCore.Entities.Concrete.Dtos.BaseDto;
using BaseCore.Entities.Concrete.Dtos.ListDto;
using BaseCore.Extensions;
using BaseCore.Models;
using BaseCore.Utilities.Results.Abstract;
using BaseCore.Utilities.Results.Concrete;
using BusinessLayer.Abstract;
using BusinessLayer.Repositories.Concrete;
using DataAccessLayer.Repositories.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class OperationClaimManager : ServiceRepository<OperationClaim, OperationClaimDto>, IOperationClaimService
    {
        private readonly IEntityRepository<OperationClaim> _repository;
        private readonly IMapper _mapper;
        public OperationClaimManager(IEntityRepository<OperationClaim> repository, IMapper mapper) : base(repository, mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [CacheAspect]
        public IDataResult<List<OperationClaimsDto>> GetAll()
        {
            var users = _repository.GetAll();
            var entities = _mapper.Map<List<OperationClaimsDto>>(users);
            return new SuccessDataResult<List<OperationClaimsDto>>(entities);
        }

    }
}
