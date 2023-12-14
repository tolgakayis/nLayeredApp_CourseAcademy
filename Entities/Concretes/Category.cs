﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Entities;

namespace Entities.Concretes
{
	public class Category : Entity<Guid>
	{
		public string Name { get; set; }
		public List<Course>? Courses { get; set; }
	}
}
