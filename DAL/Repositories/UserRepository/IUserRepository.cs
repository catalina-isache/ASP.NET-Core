using DAL.Models;
using DAL.Repository.GenericRepository;

namespace DAL.Repositories
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
        int UserRole(Guid id);
        //Task<User> GetUserByEmailAndHashedPassword(string email, string hashedPassword);
    }
}
