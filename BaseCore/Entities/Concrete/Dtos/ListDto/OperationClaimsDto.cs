using BaseCore.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseCore.Entities.Concrete.Dtos.ListDto
{
    public class OperationClaimsDto : IListDto
    {
        public string Name { get; set; }
    }
}
