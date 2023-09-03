using DAL.Models;
using DAL.Repository.GenericRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repositories
{

    public interface ICategoryForPostRepository : IGenericRepository<CategoryForPost>
    {
        Task AddAsync(CategoryForPost categoryForPost);
    }
}
