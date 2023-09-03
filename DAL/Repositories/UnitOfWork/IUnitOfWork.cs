using DAL.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repositories.UnitOfWork
{
    public interface IUnitOfWork : IDisposable
    {
        ICategoryRepository Categories { get; }
        ICategoryForPostRepository CategoryForPosts { get; }
        ICommentRepository Comments { get; }
        IUserRepository Users { get; }
        IPostRepository Posts { get; }
        ISavedListRepository SavedLists { get; }
        int Save();
    }
}
