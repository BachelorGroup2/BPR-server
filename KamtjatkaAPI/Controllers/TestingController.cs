using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using KamtjatkaAPI.Models;
using Microsoft.AspNetCore.Cors;

namespace KamtjatkaAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [EnableCors("AllowOrigin")]
    public class TestingController : ControllerBase
    {
        private readonly vujeeaxiContext _context;

        public TestingController(vujeeaxiContext context)
        {
            _context = context;
        }

        // GET: api/Testing/5
        [HttpGet("{id}")]
        public async Task<ActionResult<String>> GetSchedule(int id)
        {
            String result = "result is ";

            return result + id;
        }        
    }
}
