using Application.Interfaces;
using Application.Models;
using Azure.Core;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace Application.UseCase.Service
{
    public class ProductService : IProductService
    {
        private readonly IProductCommand _command;
        private readonly IProductQuery _query;
        private readonly ICategoryService _serviceCategory;
        private readonly ProductServiceUtils _productServiceUtils;

        public ProductService(IProductCommand command, IProductQuery query, ICategoryService serviceCategory, ProductServiceUtils productServiceUtils)
        {
            _command = command;
            _query = query;
            _serviceCategory = serviceCategory;
            _productServiceUtils = productServiceUtils;
        }

        public async Task<ProductResponse> CreateProduct(ProductRequest request)
        {
            var existeName = await _productServiceUtils.FilterProductName(request);
            await _productServiceUtils.CheckRequest(request);

            var product = new Product
            {
                Name = request.Name,
                Description = request.Description,
                Price = request.Price,
                Category = request.Category,
                Discount = request.Discount,
                ImageUrl = request.ImageUrl,

            };

            await _command.InsertProduct(product);
            var idCategory = await _serviceCategory.GetCategoryById(request.Category);

            var productResponce = new ProductResponse
            {
                Name = product.Name,
                Description = product.Description,
                Price = product.Price,
                Discount = product.Discount,
                ImageUrl = product.ImageUrl,
                Category = idCategory,

            };
            return productResponce;

        }

        public async Task<List<Product>> GetAllProducts()
        {

            List<Product> products = await _query.GetAllProductQuery();
            return products;
        }



        public async Task<List<ProductGetResponse>> GetProductFilter(ProductFilterOptions filter)
        {

            List<Product> products = await _query.GetAllProductQuery();


            if (filter.Categories != null && filter.Categories.Length > 0)
            {
                products = products.Where(p => filter.Categories.Contains(p.Category)).ToList();
            }
            if (!string.IsNullOrEmpty(filter.Name))
            {
                products = products.Where(p => p.Name.IndexOf(filter.Name, StringComparison.OrdinalIgnoreCase) >= 0).ToList();
            }

            if (filter.Limit > 0)
            {
                products = products.Skip(filter.Offset).Take(filter.Limit).ToList();
            }

            List<ProductGetResponse> response = products.Select(p => new ProductGetResponse
            {
                Id = p.ProductId,
                Name = p.Name,
                Price = p.Price,
                Discount = p.Discount,
                ImageUrl = p.ImageUrl,
                CategoryName = p.CategoryTable.Name,

            }).ToList();
            return response;
        }


        public async Task<ProductResponse> ProductDetailService(Guid id)
        {
            
            await _productServiceUtils.ProductExists(id);
            
            var product = await _query.GetProductById(id);
            var productResponse = new ProductResponse
            {

                Id = product.ProductId,
                Name = product.Name,
                Description = product.Description,
                Price = product.Price,
                Discount = product.Discount,
                ImageUrl = product.ImageUrl,
                Category = new CategoryResponse
                {
                    CategoryId = product.CategoryTable.CategoryId,
                    Name = product.CategoryTable.Name
                }

            };
            return productResponse;

        }




        public async Task<ProductResponse> UpDateProductService(Guid id, ProductRequest request)
        {
            await _productServiceUtils.ProductExists(id);
           
            await _productServiceUtils.CheckRequest(request);

            await _productServiceUtils.ChekcProductName(id, request);

            var product = await _query.GetProductById(id);

            product.Name = request.Name;
            product.Description = request.Description;
            product.Price = request.Price;
            product.Discount = request.Discount;
            product.ImageUrl = request.ImageUrl;
            product.Category = request.Category;


            var productUpDate = _command.UpDateProductComand(product);

            var productResponse = new ProductResponse
            {

                Id = product.ProductId,
                Name = product.Name,
                Description = product.Description,
                Price = product.Price,
                Discount = product.Discount,
                ImageUrl = product.ImageUrl,
                Category = new CategoryResponse
                {
                    CategoryId = product.CategoryTable.CategoryId,
                    Name = product.CategoryTable.Name
                }

            };

            return productResponse;
        }


        public async Task<ProductResponse> DeleteProductService(Guid id)
        {
            var product = await _query.GetProductById(id);
           
            await _productServiceUtils.ProductExists(id);
            await _productServiceUtils.ChekcProductSale(id);
            await _command.DeleteProduct(product);
            
            var productResponse = new ProductResponse
            {

                Id = product.ProductId,
                Name = product.Name,
                Description = product.Description,
                Price = product.Price,
                Discount = product.Discount,
                ImageUrl = product.ImageUrl,
                Category = new CategoryResponse
                {
                    CategoryId = product.CategoryTable.CategoryId,
                    Name = product.CategoryTable.Name
                }
            };

            return productResponse;
        }


    }
}


