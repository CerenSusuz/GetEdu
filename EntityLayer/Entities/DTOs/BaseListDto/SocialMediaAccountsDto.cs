using BaseCore.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Entities.DTOs.BaseListDto
{
    public class SocialMediaAccountsDto : IListDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Url { get; set; }

        public string Instructor { get; set; }
    }
}
