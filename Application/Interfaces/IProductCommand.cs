using Domain.Entities;


namespace Application.Interfaces
{
   public interface IProductCommand
    {
        public Task InsertProduct(Product product);
        public Task UpDateProductComand(Product product);
        public Task DeleteProduct(Product product);
    }
}
