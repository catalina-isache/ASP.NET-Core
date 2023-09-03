using AutoMapper;
using DAL.Models;
using DAL.Models.DTO;
using DAL.Repositories;

namespace Proiect.Services.AdminService
{
    public class AdminService : IAdminService
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;

        public AdminService(IUserRepository userRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }
        public async Task<UserDto> GetById(Guid id)
        {
            var user = await _userRepository.FindByIdAsync(id);

            if (user == null)
            {
               
                return null;
            }

            return _mapper.Map<UserDto>(user);
        }
      
        public async Task CreatePost(Post post)
        {
            await _userRepository.CreatePost(post);
            await _userRepository.SaveAsync();
        }

        public async Task DeletePost(Guid id)
        {
            var postToDelete = await _userRepository.FindPostByIdAsync(id);
            _userRepository.DeletePost(postToDelete);
            await _userRepository.SaveAsync();
        }

        public async Task DeleteComment(Guid id)
        {
            var commentToDelete = await _userRepository.FindCommentByIdAsync(id);
            _userRepository.DeleteComment(commentToDelete);
            await _userRepository.SaveAsync();
        }
    }

}
