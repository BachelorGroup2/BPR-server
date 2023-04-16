using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using KamtjatkaAPI.Models;

namespace KamtjatkaAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class KamtjatkaInfoesController : ControllerBase
    {
        private readonly vujeeaxiContext _context;

        public KamtjatkaInfoesController(vujeeaxiContext context)
        {
            _context = context;
        }

        // GET: api/KamtjatkaInfoes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<KamtjatkaInfo>>> GetKamtjatkaInfos()
        {
            return await _context.KamtjatkaInfos.ToListAsync();
        }

        // GET: api/KamtjatkaInfoes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<KamtjatkaInfo>> GetKamtjatkaInfo(int id)
        {
            var kamtjatkaInfo = await _context.KamtjatkaInfos.FindAsync(id);

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

            _context.Entry(kamtjatkaInfo).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!KamtjatkaInfoExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/KamtjatkaInfoes
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<KamtjatkaInfo>> PostKamtjatkaInfo(KamtjatkaInfo kamtjatkaInfo)
        {
            _context.KamtjatkaInfos.Add(kamtjatkaInfo);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (KamtjatkaInfoExists(kamtjatkaInfo.Id))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetKamtjatkaInfo", new { id = kamtjatkaInfo.Id }, kamtjatkaInfo);
        }

        // DELETE: api/KamtjatkaInfoes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteKamtjatkaInfo(int id)
        {
            var kamtjatkaInfo = await _context.KamtjatkaInfos.FindAsync(id);
            if (kamtjatkaInfo == null)
            {
                return NotFound();
            }

            _context.KamtjatkaInfos.Remove(kamtjatkaInfo);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool KamtjatkaInfoExists(int id)
        {
            return _context.KamtjatkaInfos.Any(e => e.Id == id);
        }
    }
}
