using DAL.Models;
using DAL.Repositories.CategoryRepository;

namespace Proiect.Services.CategoryService
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository _categoryRepository;

        public CategoryService(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        public async Task<IEnumerable<Category>> GetAllCategories()
        {
            return await _categoryRepository.GetAllCategories();
        }

        public async Task<Category> GetCategoryById(Guid id)
        {
            return await _categoryRepository.GetById(id);
        }

        public async Task<Category> CreateCategory(Category category)
        {
            return await _categoryRepository.Create(category);
        }

        public async Task<bool> DeleteCategory(Guid id)
        {
            return await _categoryRepository.Delete(id);
        }
        public async Task<List<Post>> GetPostsByCategoryId(Guid categoryId)
        {
            return await _categoryRepository.GetPostsByCategoryId(categoryId);
        }
    }

}
