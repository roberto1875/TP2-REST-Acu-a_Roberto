using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Models
{
    public class CreateProductResponce
    {
        public string ProductName { get; set; }

        public string Description { get; set; }

        public decimal Price { get; set; }

        public CategoryResponce Category { get; set; }

        public int Discount { get; set; }

        public string ImageUrl { get; set; }
    }

  
}
