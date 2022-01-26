using BaseCore.Entities.Concrete;
using DataAccessLayer.Contexts.EF;

namespace DataAccessLayer.Repositories.Abstract
{
    public interface IUserDAL : IEntityRepository<User>
    {
        List<OperationClaim> GetClaims(User user);
    }
}
