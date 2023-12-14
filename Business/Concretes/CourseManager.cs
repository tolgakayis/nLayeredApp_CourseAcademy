using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.Abstracts;
using Business.Dtos.Requests;
using Business.Dtos.Responses;
using Core.DataAccess.Paging;
using DataAccess.Abstracts;
using Entities.Concretes;
using AutoMapper;
using Microsoft.EntityFrameworkCore.InMemory.Query.Internal;
using Microsoft.EntityFrameworkCore;
using System.Net.Http.Headers;

namespace Business.Concretes
{
    public class CourseManager : ICourseService
	{
		private ICourseDal _courseDal;
		private IMapper _mapper;
		public CourseManager(ICourseDal courseDal, IMapper mapper)
		{
			_courseDal = courseDal;
			_mapper = mapper;
		}
		public async Task<CreatedCourseResponse> Add(CreateCourseRequest createCourseRequest)
		{
            Course course = _mapper.Map<Course>(createCourseRequest);
            course.Id = Guid.NewGuid();

            Course createdCourse = await _courseDal.AddAsync(course);

            return _mapper.Map<CreatedCourseResponse>(createdCourse);
        }
        public async Task<Paginate<GetListedCourseResponse>> GetListAsync()
		{
            var data = await _courseDal.GetListAsync(
                include: p => p.Include(p => p.Category).Include(b => b.Instructor));

            return _mapper.Map<Paginate<GetListedCourseResponse>>(data);
        }
        public async Task<DeletedCourseResponse> Delete(DeleteCourseRequest deleteCourseRequest)
        {
            Course course = await _courseDal.GetAsync(p => p.Id == deleteCourseRequest.CourseId);
            await _courseDal.DeleteAsync(course);
            return _mapper.Map<DeletedCourseResponse>(course);
        }

        public async Task<UpdatedCourseResponse> Update(UpdateCourseRequest updateCourseRequest)
        {
            Course course = await _courseDal.GetAsync(p => p.Id ==  updateCourseRequest.CourseId);
            _mapper.Map(updateCourseRequest, course);
            course = await _courseDal.UpdateAsync(course);
            return _mapper.Map<UpdatedCourseResponse>(course);
        }

    }
}
