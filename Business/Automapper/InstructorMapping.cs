using AutoMapper;
using Business.Dtos.Requests;
using Business.Dtos.Responses;
using Core.DataAccess.Paging;
using Entities.Concretes;

namespace Business.Automapper
{
    public class InstructorMapping : Profile
    {
        public InstructorMapping()
        {
            CreateMap<CreateInstructorRequest, Instructor>();
            CreateMap<Instructor, CreatedInstructorResponse>();

            CreateMap<Instructor, CreatedInstructorResponse>();
            CreateMap<Paginate<Instructor>, Paginate<CreatedInstructorResponse>>();
        }
    }
}
