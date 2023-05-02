using KamtjatkaAPI.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KamtjatkaAPI.Repositories
{
    public class RoomBookingRepository : RepositoryBase<RoomBooking>, IRoomBookingRepository
    {
        private readonly vujeeaxiContext appDbContext;
        public RoomBookingRepository(vujeeaxiContext appDbContext)
          : base(appDbContext)
        {
            this.appDbContext = appDbContext;
        }

        public async Task<IEnumerable<RoomBooking>> GetBookedRooms()
        {
            return await appDbContext.RoomBookings
            .Include(f => f.Room).Include(f => f.Room.RoomCategory)
            .Include(f => f.Customer) // Include the related FinanceCategory entity
            .Select(f => new RoomBooking // Project the result to a new room booking object with required properties
            {
                Id = f.Id,
                Room = f.Room,
                CustomerId = f.CustomerId,
                StartRentDate = f.StartRentDate,
                EndRentDate = f.EndRentDate,
                Customer = f.Customer // New property to hold the Name of FinanceCategory
            })
            .ToListAsync();
        }
    }
}
