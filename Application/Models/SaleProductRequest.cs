﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Models
{
    public class SaleProductRequest
    {
        public Guid ProductId { get; set; }
        public int Quantity { get; set; }
    }
}
