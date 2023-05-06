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
