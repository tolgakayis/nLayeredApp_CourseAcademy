using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.Abstracts;
using Core.DataAccess.Paging;
using DataAccess.Abstracts;
using Entities.Concretes;

namespace Business.Concretes
{
	public class CourseManager : ICourseService
	{
		private ICourseDal _courseDal;
		public CourseManager(ICourseDal courseDal)
		{
			_courseDal = courseDal;
		}
		public async Task Add(Course course)
		{
			await _courseDal.AddAsync(course);
		}

		public async Task<Paginate<Course>> GetListAsync()
		{
			var result = await _courseDal.GetListAsync();
			return result;
		}
	}
}
