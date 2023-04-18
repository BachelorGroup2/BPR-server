using KamtjatkaAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KamtjatkaAPI.Repositories
{
    public class FinanceRepository : RepositoryBase<Finance>, IFinanceRepository
    {
        public FinanceRepository(vujeeaxiContext repositoryContext)
          : base(repositoryContext)
        {

        }
    }
}
