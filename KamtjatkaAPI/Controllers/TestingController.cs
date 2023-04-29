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
    public class TestingController : ControllerBase
    {
        
        // GET: api/Testing
        [HttpGet]
        public async Task<ActionResult<String>> GetSchedules()
        {
            
            return Ok("HelloNew");
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
