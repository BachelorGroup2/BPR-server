using KamtjatkaAPI.Models;

namespace KamtjatkaAPI.Repositories
{
    public class FacilityRepository : RepositoryBase<Facility>, IFacilityRepository
    {
        public FacilityRepository(vujeeaxiContext repositoryContext)
          : base(repositoryContext)
        {

        }
    }
}
