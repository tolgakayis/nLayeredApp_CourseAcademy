using Business.Abstracts;
using Business.Dtos.Requests;
using Entities.Concretes;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class CourseController : ControllerBase
	{
		ICourseService _courseService;
		public CourseController(ICourseService courseService)
		{
			_courseService = courseService;
		}
		[HttpPost("Add")]
		public async Task<IActionResult> Add([FromBody] CreateCourseRequest createCourseRequest)
		{
			var result = await _courseService.Add(createCourseRequest);
			return Ok(result);
		}
		[HttpPost("Update")]
		public async Task<IActionResult> Update([FromBody] UpdateCourseRequest updateCourseRequest)
		{
			var result = await _courseService.Update(updateCourseRequest);
			return Ok(result);
		}
		[HttpPost("Delete")]
		public async Task<IActionResult> Delete([FromBody] DeleteCourseRequest deleteCourseRequest)
		{
			var result = await _courseService.Delete(deleteCourseRequest);
			return Ok(result);
		}
		[HttpGet("GetList")]
		public async Task<IActionResult> GetList()
		{
			var result = await _courseService.GetListAsync();
			return Ok(result);
		}
	}
}
