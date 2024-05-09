﻿

namespace Application.Models
{
    public class ProductResponse
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public int Discount { get; set; }
        public string ImageUrl { get; set; }
        public CategoryResponse Category { get; set; }
    }
}
