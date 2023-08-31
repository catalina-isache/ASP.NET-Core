using DAL.Models.DTO;
using DAL.Models;

namespace Proiect.Services.UserService
{
    public interface IUserService
    {
        UserAuthResponseDto Authenticate(UserAuthRequestDto model);
        Task Create(UserAuthRequestDto user);
        Task<List<User>> GetAllUsers();
        User GetById(Guid id);
        Task<int> UserRole(Guid id);
    }
}
