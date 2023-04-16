
using APIProject.Models;
using BPR.APIProject.Repositories;
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
