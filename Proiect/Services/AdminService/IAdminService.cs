using DAL.Models;
using DAL.Models.DTO;

namespace Proiect.Services.AdminService
{
    public interface IAdminService
    {
        Task CreatePost(Post post);
        Task DeletePost(Guid id);
        Task DeleteComment(Guid id);
        Task<UserDto> GetById(Guid id);
    }
}
