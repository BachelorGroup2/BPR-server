using KamtjatkaAPI.Models;

namespace KamtjatkaAPI.Repositories
{
    public class RoomCategoryRepository : RepositoryBase<RoomCategory>, IRoomCategoryRepository
    {
        public RoomCategoryRepository(vujeeaxiContext repositoryContext)
          : base(repositoryContext)
        {

        }
    }
}
