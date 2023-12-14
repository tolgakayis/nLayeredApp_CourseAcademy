using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Dtos.Requests
{
    public class UpdateInstructorRequest
    {
        public Guid InstructorId { get; set; }
        public string InstructorName { get; set; }

    }
}
