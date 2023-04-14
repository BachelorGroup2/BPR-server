using BPR.API.Repositories;
using BPR.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BPR.API.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class RoomCategoriesController : ControllerBase
    {
        private readonly IRoomCategoryRepository _roomCategoryRepository;

        public RoomCategoriesController(IRoomCategoryRepository roomCategoryRepository)
        {
            _roomCategoryRepository = roomCategoryRepository;
        }

        [HttpGet]
        public async Task<IEnumerable<RoomCategory>> GetRoomCategory()
        {
            return await _roomCategoryRepository.Get();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<RoomCategory>> GetRoomCategory(int id)
        {
            return await _roomCategoryRepository.Get(id);
        }
    }
}
