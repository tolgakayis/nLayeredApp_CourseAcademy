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
	public class CategoryManager : ICategoryService
	{
		private ICategoryDal _categoryDal;
		public CategoryManager(ICategoryDal categoryDal)
		{
			_categoryDal = categoryDal;
		}
		public async Task Add(Category category)
		{
			await _categoryDal.AddAsync(category);
		}

		public async Task<Paginate<Category>> GetListAsync()
		{
			var result = await _categoryDal.GetListAsync();
			return result;
		}
	}
}
