using DAL.Models;
using DAL.Repository.GenericRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repositories.CategoryRepository
{
    public interface ICategoryRepository : IGenericRepository<Category>
    {
        Task<Category> GetById(Guid id);
        Task<Category> Create(Category category);
        //Task<Category> GetCategoryWithPostsAsync(Guid categoryId);
        Task<bool> IsCategoryExist(Guid categoryId);
        Task<bool> Delete(Guid id);
        Task<List<Category>> GetAllCategories();
        Task<List<Post>> GetPostsByCategoryId(Guid categoryId);
    }
}
