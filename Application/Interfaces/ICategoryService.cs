using Application.Models;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces
{
    public interface ICategoryService
    {
        public Task<CategoryResponce> GetCategoryById(int id);
        public Task<bool> CategoryExists(int id);
    }
}
