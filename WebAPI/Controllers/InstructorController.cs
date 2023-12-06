using Business.Abstracts;
using Entities.Concretes;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class InstructorController : ControllerBase
	{
		IInstructorService _instructorService;
        public InstructorController(IInstructorService instructorService)
        {
            _instructorService = instructorService;
        }

		[HttpGet]
		public async Task<IActionResult> GetList()
		{
			var result = await _instructorService.GetListAsync();
			return Ok(result);
		}
		[HttpPost]
		public async Task<IActionResult> Add([FromBody] Instructor instructor)
		{
			await _instructorService.Add(instructor);
			return Ok();
		}
		
    }
}
