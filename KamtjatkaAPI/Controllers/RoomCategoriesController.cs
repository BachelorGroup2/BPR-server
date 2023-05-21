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
    public class RoomCategoriesController : ControllerBase
    {
        private readonly IRoomCategoryRepository _roomCategoryRepository;

        public RoomCategoriesController(IRoomCategoryRepository roomCategoryRepository)
        {
            _roomCategoryRepository = roomCategoryRepository;
        }

        // GET: api/RoomCategories
        [HttpGet]
        public async Task<ActionResult<IEnumerable<RoomCategory>>> GetRoomCategories()
        {
            var roomCategories = await _roomCategoryRepository.Get();

            return Ok(roomCategories);
        }

        // GET: api/RoomCategories/5
        [HttpGet("{id}")]
        public async Task<ActionResult<RoomCategory>> GetRoomCategory(int id)
        {
            var roomCategory = await _roomCategoryRepository.Get(id);

            if (roomCategory == null)
            {
                return NotFound();
            }

            return roomCategory;
        }

        // PUT: api/RoomCategories/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutRoomCategory(int id, RoomCategory roomCategory)
        {
            if (id != roomCategory.Id)
            {
                return BadRequest();
            }

            await _roomCategoryRepository.Update(roomCategory);
           
            return Ok("PUT successfull");
        }

        // POST: api/RoomCategories
        [HttpPost]
        public async Task<ActionResult<RoomCategory>> PostRoomCategory(RoomCategory roomCategory)
        {
            var newRoomCategory = await _roomCategoryRepository.Create(roomCategory);

            return CreatedAtAction(nameof(GetRoomCategory), new { id = newRoomCategory.Id }, newRoomCategory);
        }

        // DELETE: api/RoomCategories/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRoomCategory(int id)
        {
            var roomCategoryToDelete = await _roomCategoryRepository.Delete(id);

            if (roomCategoryToDelete == null)
            {
                return NotFound();
            }

            return Ok("Resource Deleted Succesfully");
        }

        private bool RoomCategoryExists(int id)
        {
            return _roomCategoryRepository.Get(id) != null;
        }
    }
}
