using KamtjatkaAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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
