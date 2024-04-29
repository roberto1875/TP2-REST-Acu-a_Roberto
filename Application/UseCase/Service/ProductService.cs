using Application.Interfaces;
using Application.Models;
using Azure.Core;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace Application.UseCase.Service
{
    public class ProductService:IProductService
    {
        private readonly IProductCommand _command;
        private readonly IProductQuery _query;
        private readonly ICategoryService _serviceCategory;

        public ProductService(IProductCommand command, IProductQuery query, ICategoryService serviceCategory)
        {
            _command = command;
            _query = query;
            _serviceCategory = serviceCategory;
        }

        public async Task <CreateProductResponce> CreateProduct(CreateProductRequest request)
        {
            var product = new Product
            {
                Name = request.ProductName,
                Description = request.Description,
                Price = request.Price,
                Category = request.Category,
                Discount = request.Discount,
                ImageUrl = request.ImageUrl,
                
            };

            await _command.InsertProduct(product);
            var idCategory = await _serviceCategory.GetCategoryById(request.Category); 

            var productResponce = new CreateProductResponce
            {
                ProductName = product.Name,
                Description = product.Description,
                Price = product.Price,
                Category = idCategory,
                Discount = product.Discount,
                ImageUrl = product.ImageUrl,

            };
            return productResponce;
            
        }

        public async Task <List<Product>> GetAllProducts()
        {
            
            List<Product>products = await _query.GetAllProductQuery();
            return products;
        }

        
    }
}
