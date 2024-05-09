using Application.Interfaces;
using Domain.Entities;
using Infraestructure.Persistence;
using Microsoft.EntityFrameworkCore;


namespace Infraestructure.Query
{
    public class SaleQuery:ISaleQuery
    {
      private readonly MarketDbContext _context;

        public SaleQuery(MarketDbContext context)
        {
            _context = context;
        }

        public async Task<List<Sale>> GetSaleByDate(DateTime? fromDate, DateTime? toDate)
        {
            List<Sale> sales = await _context.Sales.Include(s => s.SalesProducts)
            .Where(s => (!fromDate.HasValue || s.Date >= fromDate) && (!toDate.HasValue || s.Date <= toDate))
            .ToListAsync();
            return sales;
        }

        public async Task<Sale> GetSaleById(int id)
        {
            var sale = await _context.Sales
                 .Include(sp=> sp.SalesProducts)
                 .FirstOrDefaultAsync(p => p.SaleId == id);

            return sale;
        }
    }
}
