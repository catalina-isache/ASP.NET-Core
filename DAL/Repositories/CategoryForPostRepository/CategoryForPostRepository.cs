using DAL.Data;
using DAL.Models;
using DAL.Repository.GenericRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repositories
{

    public class CategoryForPostRepository : GenericRepository<CategoryForPost>, ICategoryForPostRepository
    {
        private readonly ProiectContext _dbContext;
        public CategoryForPostRepository(ProiectContext context) : base(context) { _dbContext = context; }
        public async Task AddAsync(CategoryForPost categoryForPost)
        {
            await _context.CategoryForPost.AddAsync(categoryForPost);
        }
    }


}