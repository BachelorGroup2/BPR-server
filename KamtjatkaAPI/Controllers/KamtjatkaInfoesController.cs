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
    public class KamtjatkaInfoesController : ControllerBase
    {
       
        private readonly IKamtjatkaInfoRepository _kamtjatkaInfoRepository;

       
        public KamtjatkaInfoesController(IKamtjatkaInfoRepository kamtjatkaInfoRepository)
        {
            _kamtjatkaInfoRepository = kamtjatkaInfoRepository;
        }

        // GET: api/KamtjatkaInfoes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<KamtjatkaInfo>>> GetKamtjatkaInfos()
        {
            
            var kamtjatkaInfo = await _kamtjatkaInfoRepository.Get();
            return Ok(kamtjatkaInfo);
        }

        // GET: api/KamtjatkaInfoes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<KamtjatkaInfo>> GetKamtjatkaInfo(int id)
        {
       
            var kamtjatkaInfo = await _kamtjatkaInfoRepository.Get(id);

            if (kamtjatkaInfo == null)
            {
                return NotFound();
            }

            return kamtjatkaInfo;
        }

        // PUT: api/KamtjatkaInfoes/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutKamtjatkaInfo(int id, KamtjatkaInfo kamtjatkaInfo)
        {
            
            if (id != kamtjatkaInfo.Id)
            {
                return BadRequest();
            }

            await _kamtjatkaInfoRepository.Update(kamtjatkaInfo);

          
            return Ok("PUT successfull");
        }

        // POST: api/KamtjatkaInfoes
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<KamtjatkaInfo>> PostKamtjatkaInfo(KamtjatkaInfo kamtjatkaInfo)
        {
           
            var newKamtjatkaInfo = await _kamtjatkaInfoRepository.Create(kamtjatkaInfo);
            return CreatedAtAction(nameof(GetKamtjatkaInfo), new { id = newKamtjatkaInfo.Id }, newKamtjatkaInfo);
        }

        // DELETE: api/KamtjatkaInfoes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteKamtjatkaInfo(int id)
        {
            var kamtjatkaInfoToDelete = await _kamtjatkaInfoRepository.Delete(id);

            if (kamtjatkaInfoToDelete == null)
            {
                return NotFound();
            }

            return Ok("Resource Deleted Succesfully");
        }

        private bool KamtjatkaInfoExists(int id)
        {
            
            return _kamtjatkaInfoRepository.Get(id) != null;
        }
    }
}
