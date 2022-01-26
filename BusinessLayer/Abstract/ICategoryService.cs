using BaseCore.Models;
using BaseCore.Utilities.Results.Abstract;
using BusinessLayer.Repositories.Abstract;
using EntityLayer.Entities.Concrete;
using EntityLayer.Entities.DTOs.BaseDtos;
using EntityLayer.Entities.DTOs.BaseListDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface ICategoryService : IServiceRepository<Category, CategoryDto>
    {
        IDataResult<List<CategoriesDto>> GetByParentId(int? id);
        IDataResult<List<CategoriesDto>> GetAll();

    }
}
