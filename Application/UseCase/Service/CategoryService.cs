using Application.Interfaces;
using Application.Models;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.UseCase.Service
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryQuery _query;

        public CategoryService(ICategoryQuery query)
        {
            _query = query;
        }

        public async Task<CategoryResponce> GetCategoryById(int id)
        {
            var categoryId = await _query.GetCategoryById(id);   
            if (categoryId != null)
            {
                CategoryResponce responce = new CategoryResponce
                {
                    CategoryId = categoryId.CategoryId,
                    Name = categoryId.Name
                };
                return responce;
            } 
            return null;
        }
    }
}
