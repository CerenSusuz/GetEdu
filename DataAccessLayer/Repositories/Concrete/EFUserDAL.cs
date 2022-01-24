using BaseCore.DataAccess.EntityFramework;
using BaseCore.Entities.Concrete;
using DataAccessLayer.Contexts.EF;
using DataAccessLayer.Repositories.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Repositories.Concrete
{
    public class EFUserDAL : EFEntityRepositoryBase<User, GetEduContext>, IUserDAL
    {
        public List<OperationClaim> GetClaims(User user)
        {
            using (var context = new GetEduContext())
            {
                var result = from operationClaim in context.OperationClaims
                             join userOperationClaim in context.UserOperationClaimPairings
                                 on operationClaim.Id equals userOperationClaim.OperationClaimId
                             where userOperationClaim.UserId == user.Id
                             select new OperationClaim { Id = operationClaim.Id, Name = operationClaim.Name };
                return result.ToList();

            }
        }
    }
}
