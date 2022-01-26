using AutoMapper;
using BaseCore.Extensions;
using BaseCore.Models;
using BaseCore.Utilities.Results.Abstract;
using BaseCore.Utilities.Results.Concrete;
using BusinessLayer.Abstract;
using BusinessLayer.Repositories.Concrete;
using DataAccessLayer.Repositories.Abstract;
using EntityLayer.Entities.Concrete;
using EntityLayer.Entities.DTOs.BaseDtos;
using EntityLayer.Entities.DTOs.BaseListDto;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class CategoryManager : ServiceRepository<Category, CategoryDto>, ICategoryService
    {
        private readonly IEntityRepository<Category> _repository;
        private readonly IMapper _mapper;
        public CategoryManager(IEntityRepository<Category> repository,IMapper mapper) : base(repository, mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public IDataResult<List<CategoriesDto>> GetByParentId(int? id)
        {
            var categories = _repository.AsNoTracking
                .Include(c => c.ParentCategory)
                .Where(c=>c.ParentCategoryId == id);
            var entities = _mapper.Map<List<CategoriesDto>>(categories);
            return new SuccessDataResult<List<CategoriesDto>>(entities);
        }

        public IDataResult<List<CategoriesDto>> GetAll()
        {
            var entities = _repository.GetAll();
            var categories = _mapper.Map<List<CategoriesDto>>(entities);
            return new SuccessDataResult<List<CategoriesDto>>(categories);
        }
        
    }
}
