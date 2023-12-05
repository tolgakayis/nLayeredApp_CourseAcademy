using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.DataAccess.Paging;
using Entities.Concretes;

namespace Business.Abstracts
{
	public interface ICategoryService
	{
		Task<Paginate<Category>> GetListAsync();
		Task Add(Category category);
	}
}
