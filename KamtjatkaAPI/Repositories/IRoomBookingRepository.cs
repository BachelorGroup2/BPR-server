﻿using KamtjatkaAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KamtjatkaAPI.Repositories
{
   public interface IRoomBookingRepository : IRepositoryBase<RoomBooking>
    {
        Task<IEnumerable<RoomBooking>> GetBookedRooms();
    }
}
