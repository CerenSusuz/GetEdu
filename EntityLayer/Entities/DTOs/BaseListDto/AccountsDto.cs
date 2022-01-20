using BaseCore.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Entities.DTOs.BaseListDto
{
    public class AccountsDto : IListDto
    {
        public int Id { get; set; }
        public string User { get; set; }
        public string Image { get; set; }
    }
}
