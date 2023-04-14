using BPR.API.Models;
using BPR.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BPR.API.Repositories
{
    public class RoomCategoryRepository : RepositoryBase<RoomCategory>, IRoomCategoryRepository
    {

        public RoomCategoryRepository(MyDBContext repositoryContext)
           : base(repositoryContext)
        {

        }

    }
}
