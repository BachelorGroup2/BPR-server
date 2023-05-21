using KamtjatkaAPI.Models;

namespace KamtjatkaAPI.Repositories
{
    public class AdministratorRepository : RepositoryBase<Administrator>, IAdministratorRepository
    {
        public AdministratorRepository(vujeeaxiContext repositoryContext)
          : base(repositoryContext)
        {

        }
    }
}
