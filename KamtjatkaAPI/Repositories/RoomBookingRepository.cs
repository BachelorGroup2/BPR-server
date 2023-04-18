using KamtjatkaAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KamtjatkaAPI.Repositories
{
    public class RoomBookingRepository : RepositoryBase<RoomBooking>, IRoomBookingRepository
    {
        public RoomBookingRepository(vujeeaxiContext repositoryContext)
          : base(repositoryContext)
        {

        }
    }
}
