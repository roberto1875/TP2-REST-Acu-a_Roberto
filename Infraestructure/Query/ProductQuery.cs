using Application.Interfaces;
using Domain.Entities;
using Infraestructure.Persistence;
using Microsoft.EntityFrameworkCore;


namespace Infraestructure.Query
{
    public class ProductQuery : IProductQuery
    {
        private readonly MarketDbContext _context;

        public ProductQuery(MarketDbContext context)
        {
            _context = context;
        }


        public async Task<List<Product>> GetAllProductQuery()
        {
            List<Product> products = await _context.Products.Include(x => x.CategoryTable).ToListAsync();

            return products;
        }


        public async Task<Product> GetProductById(Guid id)
        {

            var product = await _context.Products
                .Include(p => p.CategoryTable)
                .Include(p => p.SaleProducts)
                .FirstOrDefaultAsync(p => p.ProductId == id);
           
            return product;
        }
        
        public async Task<bool> ProductExistsByName(string name)
        {
            return await _context.Products.AnyAsync(p => p.Name == name);
        }

    }
}
