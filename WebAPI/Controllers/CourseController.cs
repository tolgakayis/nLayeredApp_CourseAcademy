using Business.Abstracts;
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
		[HttpPost]
		public async Task<IActionResult> Add([FromBody] Course course)
		{
			await _courseService.Add(course);
			return Ok();
		}
		[HttpGet]
		public async Task<IActionResult> GetList()
		{
			var result = await _courseService.GetListAsync();
			return Ok(result);
		}
	}
}
