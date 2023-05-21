using KamtjatkaAPI.Models;

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
