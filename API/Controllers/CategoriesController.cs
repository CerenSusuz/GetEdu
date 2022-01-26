using Microsoft.AspNetCore.Mvc;
using API.Repositories;
using BusinessLayer.Abstract;
using BaseCore.Entities.Concrete.Dtos.BaseDto;
using EntityLayer.Entities.DTOs.BaseDto.UserDto;
using BaseCore.Entities.Concrete;
using EntityLayer.Entities.Concrete;
using EntityLayer.Entities.DTOs.BaseDtos;

namespace WebAPI.Controllers
{
    public class CategoriesController : ControllerRepository<ICategoryService, Category, CategoryDto>
    {
        private readonly ICategoryService _categoryService;
        public CategoriesController(ICategoryService categoryService) : base(categoryService)
        {
            _categoryService = categoryService;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        public IActionResult GetByParentId(int? id)
        {
            var result = _categoryService.GetByParentId(id);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpGet("getCategories")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        public IActionResult GetAll()
        {
            var result = _categoryService.GetAll();
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

    }
}
