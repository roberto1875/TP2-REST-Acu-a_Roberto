﻿using Application.Interfaces;
using Domain.Entities;
using Infraestructure.Persistence;


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
            await _context.Sales.AddAsync(sale);
            _context.SaveChanges();
        }
        
    }
}
