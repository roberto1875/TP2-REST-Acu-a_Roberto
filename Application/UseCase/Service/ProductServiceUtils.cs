using Application.Interfaces;
using Application.Models;
using Azure.Core;
using Domain.Entities;
using static Application.Exceptions.Exceptions;


namespace Application.UseCase.Service
{
    public class ProductServiceUtils
    {
        private readonly IProductQuery _query;
        private readonly ICategoryService _categoryService;

        public ProductServiceUtils(IProductQuery query, ICategoryService categoryService)
        {
            _query = query;
            _categoryService = categoryService;
        }

        public async Task ProductExists(Guid id)
        {
            var product = await _query.GetProductById(id);

            if (product == null)
            {
                throw new ProductNotFoundException();
            }

        }

        public async Task<CreateProductRequest> FilterProductName(CreateProductRequest request)
        {
            List<Product> products = await _query.GetAllProductQuery();
            var existingProduct = products.FirstOrDefault(p => p.Name == request.Name);
            if (existingProduct == null)
            {
                return request;
            }
            else
            {
               
                throw new ConflictProductException();
            }
        }

        public async Task CheckRequest(ProductRequest request)
        {
            List<string> errorMessages = new List<string>();

            if (request.Price <= 0)
            {
                errorMessages.Add("El precio debe ser mayor a cero.");
            }

            if (request.Discount < 0 || request.Discount > 100)
            {
                errorMessages.Add("El descuento debe estar entre 0% y 100%.");
            }

            
            if (!await _categoryService.CategoryExists(request.Category))
            {
            errorMessages.Add($"La categoría '{request.Category}' no existe.");
            }

            if (errorMessages.Count > 0)
            {
             throw new BadRequestException(string.Join(" ", errorMessages));
            }

        }

        public async Task ChekcProductName(Guid id, ProductRequest request)
        {
            var name = await _query.GetProductById(id);

            if (name.Name != request.Name && await _query.ProductExistsByName(request.Name))
            {
                throw new ConflictProductException();
            }

        }


    }
}
