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
            Course course =  _mapper.Map<CreateCourseRequest, Course>(createCourseRequest);
            course.Id = Guid.NewGuid();

            Course createdCourse = await _courseDal.AddAsync(course);

            CreatedCourseResponse createdCourseResponse = _mapper.Map<CreatedCourseResponse>(createdCourse);

			return createdCourseResponse;

            //Course course = new Course();
            //course.Id = Guid.NewGuid();
            //course.CourseName = createCourseRequest.CourseName;
            //course.CourseDescription = createCourseRequest.CourseDescription;
            //course.InstructorName = createCourseRequest.InstructorName;

            //Course createdCourse = await _courseDal.AddAsync(course);

            //CreatedCourseResponse createdCourseResponse = new CreatedCourseResponse();
            //createdCourseResponse.Id = createdCourse.Id;
            //createdCourseResponse.CourseName = createCourseRequest.CourseName;
            //createdCourseResponse.CourseDescription = createCourseRequest.CourseDescription;
            //createdCourseResponse.InstructorName = createCourseRequest.InstructorName;

            //return createdCourseResponse;

        }

		// GetListCourseResponse - done
		// Tobetodaki tüm nesneleri response request patternine göre ekle - done
		// sistemi automappera çek - ?

		public async Task<Paginate<GetListCourseResponse>> GetListAsync()
		{
            var courseList = await _courseDal.GetListAsync();

            List<GetListCourseResponse> getList = _mapper.Map<List<GetListCourseResponse>>(courseList.Items);

            Paginate<GetListCourseResponse> paginate = _mapper.Map<Paginate<GetListCourseResponse>>(courseList);

            paginate.Items = getList;

            return paginate;

            //var result = _courseDal.GetListAsync();
            //
            //List<GetListCourseResponse> getList = new List<GetListCourseResponse>();
            //
            //// course list mapping
            //foreach (var item in result.Result.Items)
            //{
            //	GetListCourseResponse getListedProductResponse = new GetListCourseResponse();
            //	getListedProductResponse.Id = item.Id;
            //	getListedProductResponse.CourseName = item.CourseName;
            //	getListedProductResponse.CourseDescription = item.CourseDescription;
            //	getListedProductResponse.InstructorName = item.InstructorName;
            //	getList.Add(getListedProductResponse);
            //}
            //
            //// paginate mapping
            //Paginate<GetListCourseResponse> paginate = new Paginate<GetListCourseResponse>();
            //paginate.Pages = result.Result.Pages;
            //paginate.Items = getList;
            //paginate.Index = result.Result.Index;
            //paginate.Size = result.Result.Size;
            //paginate.Count = result.Result.Count;
            //
            //return paginate;
        }
	}
}
