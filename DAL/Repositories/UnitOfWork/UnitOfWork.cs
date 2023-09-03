using DAL.Data;
using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repositories.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private ProiectContext context;
        public UnitOfWork(ProiectContext context)
        {
            this.context = context;

            Categories = new CategoryRepository(context);
            Users = new UserRepository(context);
            CategoryForPosts = new CategoryForPostRepository(context);
            Comments = new CommentRepository(context);
            Posts = new PostRepository(context);
            SavedLists = new SavedListRepository(context);

        }
        public ICategoryRepository Categories
        {
            get;
            private set;
        }
        public ICategoryForPostRepository CategoryForPosts
        {
            get;
            private set;
        }
        public ICommentRepository Comments
        {
            get;
            private set;
        }
        public IUserRepository Users
        {
            get;
            private set;
        }
        public IPostRepository Posts
        {
            get;
            private set;
        }
        public ISavedListRepository SavedLists
        {
            get;
            private set;
        }

        public void Dispose()
        {
            context.Dispose();
        }
        public int Save()
        {
            return context.SaveChanges();
        }
    }
}
