using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Dtos.Requests
{
    public class UpdateCourseRequest
    {
        public Guid? CategoryId { get; set; }
        public Guid? InstructorId { get; set; }
        public Guid CourseId { get; set; }
        public string CourseName { get; set; }
        public string? CourseDescription { get; set; }
    }
}
