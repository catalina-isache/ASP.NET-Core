using DAL.Data;
using DAL.Models;
using DAL.Repository.GenericRepository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repositories
{
    public class CategoryRepository : GenericRepository<Category>, ICategoryRepository
    {
        private readonly ProiectContext _dbContext;
        public CategoryRepository(ProiectContext context) : base(context) { _dbContext = context; }

        public async Task<Category> GetById(Guid id)
        {
            Category? category = await _context.Categories.FindAsync(id);
            if (category == null)
            {
                throw new ArgumentException($"Category with id {id} was not found");
            }
            return category;
        }
        public async Task<Category> Create(Category category)
        {
            await _context.Categories.AddAsync(category);
            await _context.SaveChangesAsync();
            return category;
        }

        public async Task<Guid?> GetCategoryIdByName(string categoryName)
        {
            return await _context.Categories
                .Where(c => c.Name == categoryName)
                .Select(c => c.Id)
                .FirstOrDefaultAsync();
        }

        public async Task<bool> IsCategoryExist(Guid categoryId)
        {
            return await _context.Categories.AnyAsync(c => c.Id == categoryId);
        }

        public async Task<bool> Delete(Guid id)
        {
            var category = await _table.FindAsync(id);
            if (category == null)
            {
                return false;
            }
            _table.Remove(category);
            return await _context.SaveChangesAsync() > 0;
        }

        //public Task<Category> GetCategoryWithPostsAsync(Guid categoryId)
        //{
            //throw new NotImplementedException();
        //}

        public async Task<List<Category>> GetAllCategories()
        {
            return await _context.Categories
                .Select(c => new Category { Name = c.Name, Id=c.Id })
                .ToListAsync();
        }
        public async Task<List<Post>> GetPostsByCategoryId(Guid categoryId)
        {
            return await _dbContext.Posts
                .Where(p => p.CategoryForPost.Any(cfp => cfp.CategoryId == categoryId))
                .ToListAsync();
        }


    }
}
