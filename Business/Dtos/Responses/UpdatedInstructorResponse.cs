using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Dtos.Responses
{
    public class UpdatedInstructorResponse
    {
        public Guid Id { get; set; }
        public string InstructorName { get; set; }
        public DateTime UpdatedDate { get; set; }
    }
}
