using DAL.Data;
using DAL.Models;
using DAL.Repository.GenericRepository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repositories.UserRepository
{
    public class UserRepository : GenericRepository<User>, IUserRepository
    {
        public UserRepository(ProiectContext context) : base(context)
        {

        }
        public async Task CreatePost(Post post)
        {
            await _context.Posts.AddAsync(post);
        }
        public void DeletePost(Post post)
        {
            _context.Posts.Remove(post);
        }
        public async Task<Post> FindPostByIdAsync(Guid id)
        {
            return await _context.Posts.FindAsync(id);
        }
        public async Task<Comment> FindCommentByIdAsync(Guid id)
        {
            return await _context.Comments.FindAsync(id);
        }
        public async Task DeleteComment(Comment comment)
        {
            _context.Comments.Remove(comment);
        }


        public User FindByEmail(string email)
        {
            return _context.Users.SingleOrDefault(u => u.Email == email);
        }

        public User FindById(Guid id)
        {
            return _context.Users.SingleOrDefault(u => u.Id == id);
        }

        public int UserRole(Guid id)
        {
            var user = _context.Users.SingleOrDefault(u => u.Id == id);
            if (user != null)
            {
                return (int)user.Role; // Assuming 'Role' is an int property in your User model representing the user's role
            }
            return -1;
        }
    }
}
