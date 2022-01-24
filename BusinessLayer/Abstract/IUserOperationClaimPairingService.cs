using BaseCore.Entities.Concrete;
using BaseCore.Entities.Concrete.Dtos.BaseDto;
using BaseCore.Entities.Concrete.Dtos.ListDto;
using BaseCore.Models;
using BusinessLayer.Repositories.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface IUserOperationClaimPairingService 
        : IPairingServiceRepository<UserOperationClaimPairingDto>
    {
        Task<PagedList<UserOperationClaimPairingsDto>> GetAllAsync(Filter filter);
        Task<UserOperationClaimPairingsDto> GetByUserId(int userId);
        Task<UserOperationClaimPairingsDto> GetByClaimId(int userId);
    }
}
