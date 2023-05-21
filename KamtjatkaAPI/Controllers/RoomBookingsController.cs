using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using KamtjatkaAPI.Models;
using KamtjatkaAPI.Repositories;
using Microsoft.AspNetCore.Cors;

namespace KamtjatkaAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [EnableCors("AllowOrigin")]
    public class RoomBookingsController : ControllerBase
    {
        private readonly IRoomBookingRepository _roomBookingRepository;
      
        public RoomBookingsController(IRoomBookingRepository roomBookingRepository)
        {
            _roomBookingRepository = roomBookingRepository;
        }

        // GET: api/RoomBookings
        [HttpGet]
        public async Task<ActionResult<IEnumerable<RoomBooking>>> GetRoomBookings()
        {
            var roomBookings = await _roomBookingRepository.Get();

            return Ok(roomBookings);
        }

        // GET: api/RoomBookings/5
        [HttpGet("{id}")]
        public async Task<ActionResult<RoomBooking>> GetRoomBooking(int id)
        {
            var roomBookings = await _roomBookingRepository.Get(id);

            if (roomBookings == null)
            {
                return NotFound();
            }

            return roomBookings;
        }

        // PUT: api/RoomBookings/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutRoomBooking(int id, RoomBooking roomBooking)
        {
            if (id != roomBooking.Id)
            {
                return BadRequest();
            }

            await _roomBookingRepository.Update(roomBooking);
          
            return Ok("PUT successfull");
        }

        // POST: api/RoomBookings
        [HttpPost]
        public async Task<ActionResult<RoomBooking>> PostRoomBooking(RoomBooking roomBooking)
        {
            var newRoomBooking = await _roomBookingRepository.Create(roomBooking);

            return CreatedAtAction(nameof(GetRoomBooking), new { id = newRoomBooking.Id }, newRoomBooking);
        }

        // DELETE: api/RoomBookings/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRoomBooking(int id)
        {
            var roomBookingToDelete = await _roomBookingRepository.Delete(id);

            if (roomBookingToDelete == null)
            {
                return NotFound();
            }

            return Ok("Resource Deleted Succesfully");
        }

        private bool RoomBookingExists(int id)
        {
            return _roomBookingRepository.Get(id) != null;
        }
    }
}
