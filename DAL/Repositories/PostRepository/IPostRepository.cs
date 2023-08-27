using DAL.Models;
using DAL.Data;
using DAL.Repository.GenericRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repositories.PostRepository
{
    public interface IPostRepository: IGenericRepository<Post>
    {
       
    }
}
