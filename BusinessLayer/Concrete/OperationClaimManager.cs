using AutoMapper;
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
        public async Task<PagedList<OperationClaimsDto>> GetAllAsync(Filter filter)
        {
            return await Task.Run(() => _repository.AsNoTracking()
            .Filter(filter)
            .ToPagedList<OperationClaim, OperationClaimsDto>(filter, _mapper));
        }
    }
}
