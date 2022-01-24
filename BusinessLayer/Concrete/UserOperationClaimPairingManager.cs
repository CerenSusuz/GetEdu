using AutoMapper;
using BaseCore.Aspects.Caching;
using BaseCore.DataAccess.EntityFramework;
using BaseCore.Entities.Concrete;
using BaseCore.Entities.Concrete.Dtos.BaseDto;
using BaseCore.Entities.Concrete.Dtos.ListDto;
using BaseCore.Extensions;
using BaseCore.Models;
using BusinessLayer.Abstract;
using BusinessLayer.Repositories.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    internal class UserOperationClaimPairingManager 
        : PairingServiceRepository<UserOperationClaimPairing, UserOperationClaimPairingDto>
        , IUserOperationClaimPairingService
    {
        private readonly IEntityRepository<UserOperationClaimPairing> _repository;
        private readonly IMapper _mapper;
        public UserOperationClaimPairingManager(IEntityRepository<UserOperationClaimPairing> repository, IMapper mapper) : base(repository, mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [CacheAspect]
        public async Task<PagedList<UserOperationClaimPairingsDto>> GetAllAsync(Filter filter)
        {
            return await Task.Run(() => _repository.AsNoTracking()
            .Filter(filter)
            .ToPagedList<UserOperationClaimPairing, UserOperationClaimPairingsDto>(filter, _mapper));
        }

        public async Task<UserOperationClaimPairingsDto> GetByUserId(int userId)
        {
            var entities = await Task.Run(() => _repository.GetAllAsync(entity=>entity.UserId == userId));
            return _mapper.Map<UserOperationClaimPairingsDto>(entities);
        }

        public async Task<UserOperationClaimPairingsDto> GetByClaimId(int claimId)
        {
            var entities = await Task.Run(() => _repository.GetAllAsync(entity => entity.OperationClaimId == claimId));
            return _mapper.Map<UserOperationClaimPairingsDto>(entities);
        }
    }
}
