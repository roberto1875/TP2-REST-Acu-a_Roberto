using Application.Interfaces;
using Domain.Entities;
using Infraestructure.Persistence;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infraestructure.Command
{
    public class SaleCommand:ISaleCommand
    {
        private readonly MarketDbContext _context;

        public SaleCommand(MarketDbContext context)
        {
            _context = context;
        }

        public async Task AddSale(Sale sale)
        {
            _context.Sales.AddAsync(sale);
            _context.SaveChanges();
        }
        
    }
}
