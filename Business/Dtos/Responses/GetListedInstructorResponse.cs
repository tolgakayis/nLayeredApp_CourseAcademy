using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Dtos.Responses
{
    public class GetListedInstructorResponse
    {
        public Guid Id { get; set; }
        public string InstructorName { get; set; }

    }
}
