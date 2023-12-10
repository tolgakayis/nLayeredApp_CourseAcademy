using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Business.Abstracts;
using Business.Dtos.Requests;
using Business.Dtos.Responses;
using Core.DataAccess.Paging;
using DataAccess.Abstracts;
using DataAccess.Concretes;
using Entities.Concretes;

namespace Business.Concretes
{
	public class InstructorManager : IInstructorService
	{
		private IInstructorDal _instructorDal;
		private IMapper _mapper;
        public InstructorManager(IInstructorDal instructorDal, IMapper mapper)
        {
            _instructorDal = instructorDal;
			_mapper = mapper;
        }
        public async Task<CreatedInstructorResponse> Add(CreateInstructorRequest createInstructorRequest)
		{
			Instructor instructor = _mapper.Map<Instructor>(createInstructorRequest);
			instructor.Id = Guid.NewGuid();

			Instructor createdInstructor = await _instructorDal.AddAsync(instructor);

			CreatedInstructorResponse createdInstructorResponse = _mapper.Map<CreatedInstructorResponse>(createdInstructor);
			return createdInstructorResponse;

			//Instructor instructor = new Instructor();
			//instructor.Id = Guid.NewGuid();
			//instructor.InstructorName = createInstructorRequest.InstructorName;
			//
			//Instructor createdInstructor = await _instructorDal.AddAsync(instructor);
			//
			//CreatedInstructorResponse createdInstructorResponse = new CreatedInstructorResponse();
			//createdInstructorResponse.Id = createdInstructor.Id;
			//createdInstructorResponse.InstructorName = createdInstructor.InstructorName;
			//
			//return createdInstructorResponse;
		}

		public async Task<Paginate<CreatedInstructorResponse>> GetListAsync()
		{
			var instructorList = await _instructorDal.GetListAsync();

			List<CreatedInstructorResponse> getList = _mapper.Map<List<CreatedInstructorResponse>>(instructorList.Items);

			Paginate<CreatedInstructorResponse> paginate = _mapper.Map<Paginate<CreatedInstructorResponse>>(instructorList);

			paginate.Items = getList;

			return paginate;

			//var result = _instructorDal.GetListAsync();
			//
			//List<CreatedInstructorResponse> getList = new List<CreatedInstructorResponse>();
			//
			//// category list mapping
			//foreach (var item in result.Result.Items)
			//{
			//	CreatedInstructorResponse getListedInstructorResponse = new CreatedInstructorResponse();
			//	getListedInstructorResponse.Id = item.Id;
			//	getListedInstructorResponse.InstructorName = item.InstructorName;
			//	getList.Add(getListedInstructorResponse);
			//}
			//
			//// paginate mapping
			//Paginate<CreatedInstructorResponse> _paginate = new Paginate<CreatedInstructorResponse>();
			//_paginate.Pages = result.Result.Pages;
			//_paginate.Items = getList;
			//_paginate.Index = result.Result.Index;
			//_paginate.Size = result.Result.Size;
			//_paginate.Count = result.Result.Count;
			//
			//return _paginate;
		}
	}
}
