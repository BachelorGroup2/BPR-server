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
    public class AppointmentCategoriesController : ControllerBase
    {
        //private readonly vujeeaxiContext _context;
        private readonly IAppointmentCategoryRepository _appointmentCategoryRepository;

        /* public AppointmentCategoriesController(vujeeaxiContext context)
         {
             _context = context;
         }
        */

        public AppointmentCategoriesController(IAppointmentCategoryRepository appointmentCategoryRepository)
        {
            _appointmentCategoryRepository = appointmentCategoryRepository;
        }

        // GET: api/AppointmentCategories
        [HttpGet]
        public async Task<ActionResult<IEnumerable<AppointmentCategory>>> GetAppointmentCategories()
        {
            //return await _context.AppointmentCategories.ToListAsync();
            var appointmentCategories = await _appointmentCategoryRepository.Get();
            return Ok(appointmentCategories);
        }

        // GET: api/AppointmentCategories/5
        [HttpGet("{id}")]
        public async Task<ActionResult<AppointmentCategory>> GetAppointmentCategory(int id)
        {
            /*
            var appointmentCategory = await _context.AppointmentCategories.FindAsync(id);

            if (appointmentCategory == null)
            {
                return NotFound();
            }

            return appointmentCategory;
            */
            var appointmentCategory = await _appointmentCategoryRepository.Get(id);

            if (appointmentCategory == null)
            {
                return NotFound();
            }

            return appointmentCategory;
        }

        // PUT: api/AppointmentCategories/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAppointmentCategory(int id, AppointmentCategory appointmentCategory)
        {
            /*
            if (id != appointmentCategory.Id)
            {
                return BadRequest();
            }

            _context.Entry(appointmentCategory).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AppointmentCategoryExists(id))
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
            if (id != appointmentCategory.Id)
            {
                return BadRequest();
            }

            await _appointmentCategoryRepository.Update(appointmentCategory);

            return NoContent();
        }

        // POST: api/AppointmentCategories
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<AppointmentCategory>> PostAppointmentCategory(AppointmentCategory appointmentCategory)
        {
            /*
            _context.AppointmentCategories.Add(appointmentCategory);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (AppointmentCategoryExists(appointmentCategory.Id))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetAppointmentCategory", new { id = appointmentCategory.Id }, appointmentCategory);
            */
            var newAppointmentCategory = await _appointmentCategoryRepository.Create(appointmentCategory);
            return CreatedAtAction(nameof(GetAppointmentCategory), new { id = newAppointmentCategory.Id }, newAppointmentCategory);
        }

        // DELETE: api/AppointmentCategories/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAppointmentCategory(int id)
        {
            /*
            var appointmentCategory = await _context.AppointmentCategories.FindAsync(id);
            if (appointmentCategory == null)
            {
                return NotFound();
            }

            _context.AppointmentCategories.Remove(appointmentCategory);
            await _context.SaveChangesAsync();

            return NoContent();
            */
            var appointmentCategoryToDelete = await _appointmentCategoryRepository.Delete(id);

            if (appointmentCategoryToDelete == null)
            {
                return NotFound();
            }

            return (IActionResult)appointmentCategoryToDelete;
        }

        private bool AppointmentCategoryExists(int id)
        {
            //return _context.AppointmentCategories.Any(e => e.Id == id);
            return _appointmentCategoryRepository.Get(id) != null;
        }
    }
}
