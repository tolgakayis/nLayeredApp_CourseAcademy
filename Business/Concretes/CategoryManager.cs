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
using DataAccess.Concretes;
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
		public async Task<CreatedCategoryResponse> Add(CreateCategoryRequest createCategoryRequest)
		{
			Category category = new Category();
			category.Id = Guid.NewGuid();
			category.CategoryName = createCategoryRequest.CategoryName;

			Category createdCategory = await _categoryDal.AddAsync(category);

			CreatedCategoryResponse createdCategoryResponse = new CreatedCategoryResponse();
			createdCategoryResponse.Id = createdCategory.Id;
			createdCategoryResponse.CategoryName = createdCategory.CategoryName;

			return createdCategoryResponse;
		}

		public async Task<Paginate<CreatedCategoryResponse>> GetListAsync()
		{
			var result = _categoryDal.GetListAsync();

			List<CreatedCategoryResponse> getList = new List<CreatedCategoryResponse>();

			// category list mapping
			foreach (var item in result.Result.Items)
			{
				CreatedCategoryResponse getListedCategoryResponse = new CreatedCategoryResponse();
				getListedCategoryResponse.Id = item.Id;
				getListedCategoryResponse.CategoryName = item.CategoryName;
				getList.Add(getListedCategoryResponse);
			}

			// paginate mapping
			Paginate<CreatedCategoryResponse> _paginate = new Paginate<CreatedCategoryResponse>();
			_paginate.Pages = result.Result.Pages;
			_paginate.Items = getList;
			_paginate.Index = result.Result.Index;
			_paginate.Size = result.Result.Size;
			_paginate.Count = result.Result.Count;

			return _paginate;
		}
	}
}
