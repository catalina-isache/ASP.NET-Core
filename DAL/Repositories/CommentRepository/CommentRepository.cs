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

    public class CommentRepository : GenericRepository<Comment>, ICommentRepository
    {
        private readonly ProiectContext _dbContext;
        public CommentRepository(ProiectContext context) : base(context) { _dbContext = context; }

        public async Task AddAsync(Comment comm)
        {
            await _context.Comments.AddAsync(comm);
        }
    }
}
