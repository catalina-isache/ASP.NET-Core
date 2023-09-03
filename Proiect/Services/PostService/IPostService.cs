using DAL.Models;
using DAL.Models.DTO;

namespace Proiect.Services.PostService
{
    public interface IPostService
    {
        Task<Post> CreatePost(Post post, Guid categoryId);
        Post CreatePost(PostDto post);
        bool DeletePost(Guid id);
        object GetById(int userId);
        bool SavePost(Guid id, Guid postId);
         Task<Post> FindPostById(Guid id);
        Task<List<Comment>> GetCommentsByPostId(Guid postId);
        Task<Comment> CreateComm(Comment comm);
        //object GetById(Guid userId);
    }
}
