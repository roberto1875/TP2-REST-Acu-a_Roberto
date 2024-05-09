using Application.Models;


namespace Application.Interfaces
{
    public interface IProductService
    {
        //public Task<List<Product>> GetAllProducts();
        public Task<ProductResponse> CreateProduct(ProductRequest request);
        public Task<List<ProductGetResponse>> GetProductFilter(ProductFilterOptions filter);
        public Task<ProductResponse> ProductDetailService(Guid id);
        public Task<ProductResponse> UpDateProductService(Guid id, ProductRequest request);
        public Task<ProductResponse> DeleteProductService(Guid id);
    }
}
