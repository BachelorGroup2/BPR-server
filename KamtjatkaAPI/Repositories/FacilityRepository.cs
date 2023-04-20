using KamtjatkaAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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
