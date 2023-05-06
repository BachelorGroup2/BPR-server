using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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
        //private readonly vujeeaxiContext _context;
        private readonly IRoomBookingRepository _roomBookingRepository;

        /*public RoomBookingsController(vujeeaxiContext context)
        {
            _context = context;
        }
        */
        public RoomBookingsController(IRoomBookingRepository roomBookingRepository)
        {
            _roomBookingRepository = roomBookingRepository;
        }

        // GET: api/RoomBookings
        [HttpGet]
        public async Task<ActionResult<IEnumerable<RoomBooking>>> GetRoomBookings()
        {
            //return await _context.RoomBookings.ToListAsync();
            var roomBookings = await _roomBookingRepository.GetBookedRooms();
            return Ok(roomBookings);
        }

        // GET: api/RoomBookings/5
        [HttpGet("{id}")]
        public async Task<ActionResult<RoomBooking>> GetRoomBooking(int id)
        {
            /*
            var roomBooking = await _context.RoomBookings.FindAsync(id);

            if (roomBooking == null)
            {
                return NotFound();
            }

            return roomBooking;
            */
            var roomBookings = await _roomBookingRepository.Get(id);

            if (roomBookings == null)
            {
                return NotFound();
            }

            return roomBookings;
        }

        // PUT: api/RoomBookings/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutRoomBooking(int id, RoomBooking roomBooking)
        {
            /*
            if (id != roomBooking.Id)
            {
                return BadRequest();
            }

            _context.Entry(roomBooking).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RoomBookingExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
            */
            if (id != roomBooking.Id)
            {
                return BadRequest();
            }

            await _roomBookingRepository.Update(roomBooking);

            return NoContent();
        }

        // POST: api/RoomBookings
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<RoomBooking>> PostRoomBooking(RoomBooking roomBooking)
        {
            /*
            _context.RoomBookings.Add(roomBooking);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (RoomBookingExists(roomBooking.Id))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetRoomBooking", new { id = roomBooking.Id }, roomBooking);
            */
            var newRoomBooking = await _roomBookingRepository.Create(roomBooking);
            return CreatedAtAction(nameof(GetRoomBooking), new { id = newRoomBooking.Id }, newRoomBooking);
        }

        // DELETE: api/RoomBookings/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRoomBooking(int id)
        {
            /*
            var roomBooking = await _context.RoomBookings.FindAsync(id);
            if (roomBooking == null)
            {
                return NotFound();
            }

            _context.RoomBookings.Remove(roomBooking);
            await _context.SaveChangesAsync();

            return NoContent();
            */
            var roomBookingToDelete = await _roomBookingRepository.Delete(id);

            if (roomBookingToDelete == null)
            {
                return NotFound();
            }

            return Ok("Resource Deleted Succesfully");
        }

        private bool RoomBookingExists(int id)
        {
            // return _context.RoomBookings.Any(e => e.Id == id);
            return _roomBookingRepository.Get(id) != null;
        }
    }
}
