using BaseCore.Entities.Concrete;
using BaseCore.Entities.Concrete.Dtos.BaseDto;
using BaseCore.Entities.Concrete.Dtos.ListDto;
using BaseCore.Models;
using BusinessLayer.Repositories.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface IOperationClaimService : IServiceRepository<OperationClaimDto>
    {
        Task<PagedList<OperationClaimsDto>> GetAllAsync(Filter filter);
    }
}
