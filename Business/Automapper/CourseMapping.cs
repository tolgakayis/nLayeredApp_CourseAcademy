using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Business.Dtos.Requests;
using Business.Dtos.Responses;
using Core.DataAccess.Paging;
using Core.Entities;
using Entities.Concretes;

namespace Business.Automapper
{
    public class CourseMapping : Profile
    {
        public CourseMapping()
        {
            CreateMap<CreateCourseRequest, Course>();
            CreateMap<Course, CreatedCourseResponse>();

            CreateMap<Course, GetListCourseResponse>();
            CreateMap<Paginate<Course>, Paginate<GetListCourseResponse>>();
        }
    }
    //public class InstructorMapping : Profile
    //{ public InstructorMapping()
    //    {
    //
    //    } }
}
