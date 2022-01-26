using BaseCore.Entities.Concrete;
using BaseCore.Entities.Concrete.Dtos.BaseDto;
using BaseCore.Entities.Concrete.Dtos.ListDto;
using BaseCore.Utilities.Results.Abstract;
using BusinessLayer.Repositories.Abstract;

namespace BusinessLayer.Abstract
{
    public interface IOperationClaimService : IServiceRepository<OperationClaim,OperationClaimDto>
    {
        IDataResult<List<OperationClaimsDto>> GetAll();
    }
}
