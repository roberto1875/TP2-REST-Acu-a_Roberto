
using Domain.Entities;


namespace Application.Interfaces
{
    public interface IProductQuery
    {
        public Task<List<Product>> GetAllProductQuery();
        public Task<Product> GetProductById(Guid id);
        public Task<bool> ProductExistsByName(string name);


    }
}
