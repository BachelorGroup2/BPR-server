using KamtjatkaAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KamtjatkaAPI.Repositories
{
    public class FinanceCategoryRepository : RepositoryBase<FinanceCategory>, IFinanceCategoryRepository
    {
        public FinanceCategoryRepository(vujeeaxiContext repositoryContext)
          : base(repositoryContext)
        {

        }
    }
}
