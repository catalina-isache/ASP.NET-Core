using DAL.Models;

namespace Proiect.Services.CategoryService
{
    public interface ICategoryService
    {
        Task<IEnumerable<Category>> GetAllCategories();
        Task<Category> GetCategoryById(Guid id);
        Task<Category> CreateCategory(Category category);
        Task<bool> DeleteCategory(Guid id);
        Task<List<Post>> GetPostsByCategoryId(Guid categoryId);
    }

}
