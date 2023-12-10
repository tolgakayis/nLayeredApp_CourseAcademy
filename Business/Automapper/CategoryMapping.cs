using AutoMapper;
using Business.Dtos.Requests;
using Business.Dtos.Responses;
using Core.DataAccess.Paging;
using Entities.Concretes;

namespace Business.Automapper
{
    public class CategoryMapping : Profile
    {
        public CategoryMapping()
        {
            CreateMap<CreateCategoryRequest, Category>();
            CreateMap<Category, CreatedCategoryResponse>();

            CreateMap<Category, CreatedCategoryResponse>();
            CreateMap<Paginate<Category>, Paginate<CreatedCategoryResponse>>();
        }
    }
}
