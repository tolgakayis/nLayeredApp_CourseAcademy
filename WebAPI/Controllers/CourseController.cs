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
		[HttpPost]
		public async Task<IActionResult> Add([FromBody] CreateCourseRequest createCourseRequest)
		{
			var result = await _courseService.Add(createCourseRequest);
			return Ok(result);
		}
		[HttpGet]
		public async Task<IActionResult> GetList()
		{
			var result = await _courseService.GetListAsync();
			return Ok(result);
		}
	}
}
