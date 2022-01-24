using BaseCore.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseCore.Entities.Concrete.Dtos.BaseDto
{
    public class UserOperationClaimPairingDto : IDto
    {
        public int UserId { get; set; }
        public int OperationClaimId { get; set; }
    }
}
