﻿using Application.Interfaces;
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
    public  class ProductCommand: IProductCommand
    {
        private readonly MarketDbContext _context;

        public ProductCommand(MarketDbContext context)
        {
            _context = context;
        }

        public async Task InsertProduct(Product product)
        {
            _context.Products.Add(product);
            await _context.SaveChangesAsync();

        }
        
        public async Task UpDateProductComand(Product product)
        {
            _context.Products.Update(product);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteProduct(Product product)
        {
            _context.Products.Remove(product);
            await _context.SaveChangesAsync();
        }


    }
}
