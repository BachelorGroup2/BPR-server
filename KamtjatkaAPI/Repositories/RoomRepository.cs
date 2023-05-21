using KamtjatkaAPI.Models;

namespace KamtjatkaAPI.Repositories
{
    public class RoomRepository : RepositoryBase<Room>, IRoomRepository
    {
        public RoomRepository(vujeeaxiContext repositoryContext)
          : base(repositoryContext)
        {

        }
    }
}
