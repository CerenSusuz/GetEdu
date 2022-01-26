using BaseCore.Entities.Concrete;
using DataAccessLayer.Contexts.EF;
using DataAccessLayer.Repositories.Abstract;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Repositories.Concrete
{
    public class EFUserDAL : EFEntityRepositoryBase<User>, IUserDAL
    {
        private readonly GetEduContext _context;

        public EFUserDAL(GetEduContext context) : base(context)
        {
            _context = context;
        }

        public List<OperationClaim> GetClaims(User user)
        {
                var result = from operationClaim in _context.OperationClaims
                             join userOperationClaim in _context.UserOperationClaimPairings
                                 on operationClaim.Id equals userOperationClaim.OperationClaimId
                             where userOperationClaim.UserId == user.Id
                             select new OperationClaim { Id = operationClaim.Id, Name = operationClaim.Name };
                return result.ToList();

            
        }
    }
}
