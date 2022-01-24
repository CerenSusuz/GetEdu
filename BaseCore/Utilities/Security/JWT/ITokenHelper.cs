using BaseCore.Entities.Concrete;
using BaseCore.Entities.Concrete.Dtos.ListDto;
using System;
using System.Collections.Generic;
using System.Text;

namespace BaseCore.Utilities.Security.JWT
{
    public interface ITokenHelper
    {
        AccessToken CreateToken(User user, List<OperationClaim> operationClaims);
    }
}
