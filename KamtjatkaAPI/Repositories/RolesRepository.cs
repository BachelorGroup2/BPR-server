using KamtjatkaAPI.Models;

namespace KamtjatkaAPI.Repositories
{
    public class RolesRepository : RepositoryBase<Roles>, IRolesRepository
    {
        public RolesRepository(vujeeaxiContext repositoryContext)
          : base(repositoryContext)
        {

        }
    }
}
