using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Dtos.Responses
{
    public class UpdatedCourseResponse
    {
        public Guid Id { get; set; }
        public string CategoryName { get; set; }
        public string CourseName { get; set; }
        public string CourseDescription { get; set; }
        public string InstructorName { get; set; }
        public DateTime UpdatedDate { get; set; }
    }
}
