﻿

namespace Application.Models
{
    public class SaleProductReponse
    {
        public int Id { get; set; }
        public Guid ProductId { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }
        public int Discount { get; set; }
    }
}
