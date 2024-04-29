﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Product
    {
        public Guid ProductId { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public decimal Price { get; set; }

        public int Category { get; set; }

        public int Discount { get; set; }

        public string ImageUrl { get; set; }

        public virtual Category CategoryTable { get; set; }

        public ICollection<SaleProduct> SaleProducts { get; set; }
    }
}
