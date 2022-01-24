using BaseCore.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseCore.Entities.Concrete.Dtos.ListDto
{
    public class UserOperationClaimPairingsDto : IListDto
    {
        public string User { get; set; }
        public string OperationClaim { get; set; }
    }
}
