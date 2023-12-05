using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Entities;

namespace Entities.Concretes
{
	public class Course : Entity<Guid>
	{
		//public int CourseId { get; set; }
		public string CourseName { get; set; }
		public string? CourseDescription { get; set; }
		public string? InstructorName {  get; set; }
	}
}
