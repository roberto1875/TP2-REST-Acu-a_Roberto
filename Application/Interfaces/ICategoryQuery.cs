using Domain.Entities;


namespace Application.Interfaces
{
    public interface ICategoryQuery
    {
        public Task<Category> GetCategoryById(int id);
    }
}
