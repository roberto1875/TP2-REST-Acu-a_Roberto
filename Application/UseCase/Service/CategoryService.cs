using Application.Interfaces;
using Application.Models;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Application.Exceptions.Exceptions;

namespace Application.UseCase.Service
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryQuery _query;

        public CategoryService(ICategoryQuery query)
        {
            _query = query;
        }

        public async Task<CategoryResponse> GetCategoryById(int id)
        {
            var categoryId = await _query.GetCategoryById(id);   
            if (categoryId != null)
            {
                CategoryResponse responce = new CategoryResponse
                {
                    CategoryId = categoryId.CategoryId,
                    Name = categoryId.Name
                };
                return responce;
            } 
            return null;
        }

      
        public async Task<bool> CategoryExists(int id)
        {
            var category = await _query.GetCategoryById(id);
            return category != null;
        }



    }





}
