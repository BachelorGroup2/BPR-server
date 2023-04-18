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
    public class FacilitiesController : ControllerBase
    {
        // private readonly vujeeaxiContext _context;
        private readonly IFacilityRepository _facilityRepository;

        /*  public FacilitiesController(vujeeaxiContext context)
          {
              _context = context;
          }
        */
        public FacilitiesController(IFacilityRepository facilityRepository)
        {
            _facilityRepository = facilityRepository;
        }

        // GET: api/Facilities
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Facility>>> GetFacilities()
        {
            //return await _context.Facilities.ToListAsync();
            var facilities = await _facilityRepository.Get();
            return Ok(facilities);
        }

        // GET: api/Facilities/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Facility>> GetFacility(int id)
        {
            /*
            var facility = await _context.Facilities.FindAsync(id);

            if (facility == null)
            {
                return NotFound();
            }

            return facility;
            */
            var facility = await _facilityRepository.Get(id);

            if (facility == null)
            {
                return NotFound();
            }

            return facility;
        }

        // PUT: api/Facilities/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutFacility(int id, Facility facility)
        {
            /*
            if (id != facility.Id)
            {
                return BadRequest();
            }

            _context.Entry(facility).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!FacilityExists(id))
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
            if (id != facility.Id)
            {
                return BadRequest();
            }

            await _facilityRepository.Update(facility);

            return NoContent();
        }

        // POST: api/Facilities
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Facility>> PostFacility(Facility facility)
        {
            /*
            _context.Facilities.Add(facility);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (FacilityExists(facility.Id))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetFacility", new { id = facility.Id }, facility);
            */
            var newFacility = await _facilityRepository.Create(facility);
            return CreatedAtAction(nameof(GetFacility), new { id = newFacility.Id }, newFacility);
        }

        // DELETE: api/Facilities/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteFacility(int id)
        {
            /*
            var facility = await _context.Facilities.FindAsync(id);
            if (facility == null)
            {
                return NotFound();
            }

            _context.Facilities.Remove(facility);
            await _context.SaveChangesAsync();

            return NoContent();
            */
            var facilityToDelete = await _facilityRepository.Delete(id);

            if (facilityToDelete == null)
            {
                return NotFound();
            }

            return (IActionResult)facilityToDelete;
        }

        private bool FacilityExists(int id)
        {
            //return _context.Facilities.Any(e => e.Id == id);
            return _facilityRepository.Get(id) != null;
        }
    }
}
