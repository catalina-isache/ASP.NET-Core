using DAL.Models;
using DAL.Repository.GenericRepository;

namespace DAL.Repositories.UserRepository
{
    public interface IUserRepository : IGenericRepository<User>
    {
        User FindByEmail(string email);
        User FindById(Guid id);
        Task CreatePost(Post post);
        void DeletePost(Post post);
        Task<Post> FindPostByIdAsync(Guid id);
        Task<Comment> FindCommentByIdAsync(Guid id);
        Task DeleteComment(Comment comment);

    }
}
