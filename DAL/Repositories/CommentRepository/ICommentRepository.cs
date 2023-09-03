using DAL.Models;
using DAL.Repository.GenericRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repositories
{
    public interface ICommentRepository : IGenericRepository<Comment>
    {
        Task AddAsync(Comment comm);
    }
}
