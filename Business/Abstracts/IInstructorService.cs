using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.Dtos.Requests;
using Business.Dtos.Responses;
using Core.DataAccess.Paging;
using Entities.Concretes;

namespace Business.Abstracts
{
	public interface IInstructorService
	{
		Task<Paginate<CreatedInstructorResponse>> GetListAsync();
		Task<CreatedInstructorResponse> Add(CreateInstructorRequest createInstructorRequest);
	}
}
