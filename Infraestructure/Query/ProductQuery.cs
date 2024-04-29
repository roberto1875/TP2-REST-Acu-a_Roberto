using Application.Interfaces;
using Domain.Entities;
using Infraestructure.Persistence;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

        public Task<Product> GetProductById(Guid id)
        {
            throw new NotImplementedException();
        }
    }
}
