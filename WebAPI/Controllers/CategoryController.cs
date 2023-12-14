using Business.Abstracts;
using Business.Dtos.Requests;
using Entities.Concretes;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class CategoryController : ControllerBase
	{
		ICategoryService _categoryService;
        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }
        [HttpPost("Add")]
        public async Task<IActionResult> Add([FromBody] CreateCategoryRequest createCategoryRequest)
		{
			var result = await _categoryService.Add(createCategoryRequest);
			return Ok(result);
        }
        [HttpPost("Update")]
        public async Task<IActionResult> Update([FromBody] UpdateCategoryRequest updateCategoryRequest)
        {
            var result = await _categoryService.Update(updateCategoryRequest);
            return Ok(result);
        }
        [HttpPost("Delete")]
        public async Task<IActionResult> Delete([FromBody] DeleteCategoryRequest deleteCategoryRequest)
        {
            var result = await _categoryService.Delete(deleteCategoryRequest);
            return Ok(result);
        }
        [HttpGet("GetList")]
        public async Task<IActionResult> GetList()
		{
			var result = await _categoryService.GetListAsync();
			return Ok(result);
		}
    }
}
