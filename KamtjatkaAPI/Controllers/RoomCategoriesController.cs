using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using KamtjatkaAPI.Models;
using KamtjatkaAPI.Repositories;

namespace KamtjatkaAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoomCategoriesController : ControllerBase
    {
        // private readonly vujeeaxiContext _context;
        private readonly IRoomCategoryRepository _roomCategoryRepository;

        /* public RoomCategoriesController(vujeeaxiContext context)
         {
             _context = context;
         }
        */

        public RoomCategoriesController(IRoomCategoryRepository roomCategoryRepository)
        {
            _roomCategoryRepository = roomCategoryRepository;
        }

        // GET: api/RoomCategories
        [HttpGet]
        public async Task<ActionResult<IEnumerable<RoomCategory>>> GetRoomCategories()
        {
            //return await _context.RoomCategories.ToListAsync();
            var roomCategories = await _roomCategoryRepository.Get();
            return Ok(roomCategories);
        }

        // GET: api/RoomCategories/5
        [HttpGet("{id}")]
        public async Task<ActionResult<RoomCategory>> GetRoomCategory(int id)
        {
            /*
            var roomCategory = await _context.RoomCategories.FindAsync(id);

            if (roomCategory == null)
            {
                return NotFound();
            }

            return roomCategory;
            */
            var roomCategory = await _roomCategoryRepository.Get(id);

            if (roomCategory == null)
            {
                return NotFound();
            }

            return roomCategory;
        }

        // PUT: api/RoomCategories/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutRoomCategory(int id, RoomCategory roomCategory)
        {
            /*
            if (id != roomCategory.Id)
            {
                return BadRequest();
            }

            _context.Entry(roomCategory).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RoomCategoryExists(id))
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
            if (id != roomCategory.Id)
            {
                return BadRequest();
            }

            await _roomCategoryRepository.Update(roomCategory);

            return NoContent();
        }

        // POST: api/RoomCategories
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<RoomCategory>> PostRoomCategory(RoomCategory roomCategory)
        {
            /*
            _context.RoomCategories.Add(roomCategory);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (RoomCategoryExists(roomCategory.Id))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetRoomCategory", new { id = roomCategory.Id }, roomCategory);
            */
            var newRoomCategory = await _roomCategoryRepository.Create(roomCategory);
            return CreatedAtAction(nameof(GetRoomCategory), new { id = newRoomCategory.Id }, newRoomCategory);
        }

        // DELETE: api/RoomCategories/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRoomCategory(int id)
        {
            /*
            var roomCategory = await _context.RoomCategories.FindAsync(id);
            if (roomCategory == null)
            {
                return NotFound();
            }

            _context.RoomCategories.Remove(roomCategory);
            await _context.SaveChangesAsync();

            return NoContent();
            */
            var roomCategoryToDelete = await _roomCategoryRepository.Delete(id);

            if (roomCategoryToDelete == null)
            {
                return NotFound();
            }

            return (IActionResult)roomCategoryToDelete;
        }

        private bool RoomCategoryExists(int id)
        {
            //return _context.RoomCategories.Any(e => e.Id == id);
            return _roomCategoryRepository.Get(id) != null;
        }
    }
}
