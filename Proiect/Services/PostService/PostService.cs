using DAL.Models;
using DAL.Models.DTO;
using DAL.Repositories.UnitOfWork;
using Microsoft.AspNetCore.Cryptography.KeyDerivation;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using BCryptNet = BCrypt.Net.BCrypt;
using System.Text;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace Proiect.Services.PostService
{
    public class PostService : IPostService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IConfiguration _configuration;
        public IMapper _mapper;

        public PostService(IUnitOfWork unitOfWork, IMapper mapper, IConfiguration configuration)
        {
            _unitOfWork = unitOfWork;
            _configuration = configuration;
            _mapper = mapper;
        }
      
        public object GetById(int userId)
        {
            var user = _unitOfWork.Users.FindById(userId);
            if (user == null)
            {
                return null;
            }
            return user;
        }

        async Task<Post> IPostService.CreatePost(Post post, Guid categoryId)
        {
            post.Id = Guid.NewGuid();

            var categoryForPost = new CategoryForPost
            {
                CategoryId = categoryId,
                PostId = post.Id
            };

         
            await _unitOfWork.Posts.AddAsync(post);
            await _unitOfWork.CategoryForPosts.AddAsync(categoryForPost);
            await _unitOfWork.Posts.SaveAsync();
            await _unitOfWork.CategoryForPosts.SaveAsync();
          
            var x = _unitOfWork.Save();

         
            return post;
        }
        async Task<Comment> IPostService.CreateComm(Comment comm)
        {
            comm.Id = Guid.NewGuid();
            await _unitOfWork.Comments.AddAsync(comm);
            await _unitOfWork.Comments.SaveAsync();
            
           
            var x = _unitOfWork.Save();
            return comm;
        }
        Post IPostService.CreatePost(PostDto post)
        {
            throw new NotImplementedException();
        }

        public bool DeletePost(Guid postId)
        {
         
            var deleted = _unitOfWork.Posts.DeleteAsync(postId).Result;

            return deleted;
        }
        public bool SavePost(Guid postId, Guid userId)
        {
         
            var saved  = true;
            return saved;
        }

        public async Task<List<Comment>> GetCommentsByPostId(Guid postId)
        {
            return await _unitOfWork.Posts.GetCommentsByPostId(postId);
        }

        object IPostService.GetById(int userId)
        {
            throw new NotImplementedException();
        }
        public async Task<Post> FindPostById(Guid id)
        {
            try
            {
             
                var post = await _unitOfWork.Posts.FindAsync(id);

                return post;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
    }
}
