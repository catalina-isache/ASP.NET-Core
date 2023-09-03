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
    public class PostRepository : GenericRepository<Post>, IPostRepository
    {
        private readonly ProiectContext _dbContext;
        public PostRepository(ProiectContext context) : base(context) { _dbContext = context; }
        public async Task AddAsync(Post post)
        {
            await _context.Posts.AddAsync(post);
        }
        public async Task<bool> DeleteAsync(Guid postId)
        {
            var post = await _dbContext.Posts.FindAsync(postId);

            if (post != null)
            {
                _dbContext.Posts.Remove(post);
                await _dbContext.SaveChangesAsync();
                return true;
            }

            return false; 
        }
        public async Task<Post> FindAsync(Guid id)
        {
            return await _context.Posts.FindAsync(id);
        }

        public async Task<List<Comment>> GetCommentsByPostId(Guid postId)
        {
            return await _dbContext.Comments
        .Where(c => c.PostId == postId)
        .Join(
            _dbContext.Users,
            comment => comment.UserId,
            user => user.Id,
            (comment, user) => new Comment
            {
                Id = comment.Id,
                Content = comment.Content,
                PostId = comment.PostId,
                UserId = comment.UserId,
                DateCreated = comment.DateCreated,
                DateModified = comment.DateModified,
                User = user 
            }
        )
        .ToListAsync();
        }
    }
}
