﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Dtos.Requests
{
    public class UpdateCategoryRequest
    {
        public Guid CategoryId { get; set; }
        public string CategoryName { get; set; }
    }
}
