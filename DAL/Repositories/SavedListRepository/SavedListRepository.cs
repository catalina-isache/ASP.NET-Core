using DAL.Data;
using DAL.Models;
using DAL.Repository.GenericRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repositories
{

    public class SavedListRepository : GenericRepository<SavedList>, ISavedListRepository
    {
        private readonly ProiectContext _dbContext;
        public SavedListRepository(ProiectContext context) : base(context) { _dbContext = context; }

    }
}
