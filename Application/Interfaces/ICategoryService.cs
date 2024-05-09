using Application.Models;


namespace Application.Interfaces
{
    public interface ICategoryService
    {
        public Task<CategoryResponse> GetCategoryById(int id);
        public Task<bool> CategoryExists(int id);
    }
}
