using DAL.Models;
using DAL.Data;
using DAL.Repository.GenericRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repositories
{
    public interface IPostRepository : IGenericRepository<Post>
    {
        Task AddAsync(Post post);
        Task<bool> DeleteAsync(Guid postId);
        Task<Post> FindAsync(Guid id);
        Task<List<Comment>> GetCommentsByPostId(Guid postId);
    }
}
