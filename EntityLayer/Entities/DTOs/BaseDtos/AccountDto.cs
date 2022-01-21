using BaseCore.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Entities.DTOs.BaseDtos
{
    public class AccountDto : IDto
    {
        public int UserId { get; set; }
        public int ImageId { get; set; }
    }
}
