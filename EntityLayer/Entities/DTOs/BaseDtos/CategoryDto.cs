using BaseCore.Entities.Abstract;
using EntityLayer.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Entities.DTOs.BaseDtos
{
    public class CategoryDto :IDto
    {
        public string Name { get; set; }
        public int ParentCategoryId { get; set; }
    }
}
