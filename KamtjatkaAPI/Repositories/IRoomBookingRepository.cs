using KamtjatkaAPI.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace KamtjatkaAPI.Repositories
{
    public interface IRoomBookingRepository : IRepositoryBase<RoomBooking>
    {
        Task<IEnumerable<RoomBooking>> GetBookedRooms();
    }
}
