using Application.Interfaces;
using Domain.Entities;
using Infraestructure.Persistence;
using Microsoft.EntityFrameworkCore;


namespace Infraestructure.Query
{
    public class CategoryQuery : ICategoryQuery
    {
        private readonly MarketDbContext _context;

        public CategoryQuery(MarketDbContext context)
        {
            _context = context;
        }

        public async Task<Category> GetCategoryById(int id)
        {
            var category = await _context.Categories.FirstOrDefaultAsync(x => x.CategoryId == id);
            return category;
        }
    }
}
