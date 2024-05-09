﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Models
{
    public class ProductRequest
    {
        public string Name { get; set; }
        public string? Description { get; set; }
        public decimal Price { get; set; }  
        public int Discount { get; set; }
        public string? ImageUrl { get; set; }
        public int Category { get; set; }
    }

}
