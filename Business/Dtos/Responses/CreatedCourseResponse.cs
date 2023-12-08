using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Dtos.Responses
{
	public class CreatedCourseResponse
	{
		public Guid Id { get; set; }
		public string CourseName { get; set; }
		public string? CourseDescription { get; set; }
		public string InstructorName { get; set; }
	}
}
