using DAL.Data;
using DAL.Models;
using Demo.Repository.GenericRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace DAL.Repositories.PostRepository
{
    public class PostRepository : GenericRepository<Post>, IPostRepository
    {
        private readonly ProiectContext _dbContext;
        public PostRepository(ProiectContext context) : base(context) { _dbContext = context; }

    }
}
