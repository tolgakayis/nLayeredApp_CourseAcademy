using Business.Abstracts;
using Business.Dtos.Requests;
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
		[HttpPost("Add")]
		public async Task<IActionResult> Add([FromBody] CreateInstructorRequest createInstructorRequest)
		{
			var result = await _instructorService.Add(createInstructorRequest);
			return Ok(result);
		}
        [HttpPost("Update")]
        public async Task<IActionResult> Update([FromBody] UpdateInstructorRequest updateInstructorRequest)
        {
            var result = await _instructorService.Update(updateInstructorRequest);
            return Ok(result);
        }
        [HttpPost("Delete")]
        public async Task<IActionResult> Delete([FromBody] DeleteInstructorRequest deleteInstructorRequest)
        {
            var result = await _instructorService.Delete(deleteInstructorRequest);
            return Ok(result);
        }
        [HttpGet("GetList")]
        public async Task<IActionResult> GetList()
        {
            var result = await _instructorService.GetListAsync();
            return Ok(result);
        }
    }
}
