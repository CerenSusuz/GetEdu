using BaseCore.Entities.Abstract;
using EntityLayer.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Entities.DTOs.BaseListDto
{
    public class CategoriesDto : IListDto
    {
        public string Name { get; set; }
        public string ParentCategory { get; set; }
    }
}
