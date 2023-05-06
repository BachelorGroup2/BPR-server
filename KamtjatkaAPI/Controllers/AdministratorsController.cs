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
    public class AdministratorsController : ControllerBase
    {
        //private readonly vujeeaxiContext _context;
        private readonly IAdministratorRepository _administratorRepository;

        /*
        public AdministratorsController(vujeeaxiContext context)
        {
            _context = context;
        }
        */

        public AdministratorsController(IAdministratorRepository administratorRepository)
        {
            _administratorRepository = administratorRepository;
        }

        // GET: api/Administrators
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Administrator>>> GetAdministrators()
        {
            // return await _context.Administrators.ToListAsync();
            var administrators = await _administratorRepository.Get();
            return Ok(administrators);
        }

        // GET: api/Administrators/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Administrator>> GetAdministrator(int id)
        {
            /* var administrator = await _context.Administrators.FindAsync(id);

             if (administrator == null)
             {
                 return NotFound();
             }

             return administrator;
            */

            var administrator = await _administratorRepository.Get(id);

            if (administrator == null)
            {
                return NotFound();
            }

            return administrator;
        }

        // PUT: api/Administrators/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAdministrator(int id, Administrator administrator)
        {
            /* if (id != administrator.Id)
             {
                 return BadRequest();
             }

             _context.Entry(administrator).State = EntityState.Modified;

             try
             {
                 await _context.SaveChangesAsync();
             }
             catch (DbUpdateConcurrencyException)
             {
                 if (!AdministratorExists(id))
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
            if (id != administrator.Id)
            {
                return BadRequest();
            }

            await _administratorRepository.Update(administrator);

            return NoContent();
        }

        // POST: api/Administrators
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Administrator>> PostAdministrator(Administrator administrator)
        {
            /*
            _context.Administrators.Add(administrator);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (AdministratorExists(administrator.Id))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetAdministrator", new { id = administrator.Id }, administrator);
            */
            var newAdministrator = await _administratorRepository.Create(administrator);
            return CreatedAtAction(nameof(GetAdministrator), new { id = newAdministrator.Id }, newAdministrator);
        }

        // DELETE: api/Administrators/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAdministrator(int id)
        {
            /*
            var administrator = await _context.Administrators.FindAsync(id);
            if (administrator == null)
            {
                return NotFound();
            }

            _context.Administrators.Remove(administrator);
            await _context.SaveChangesAsync();

            return NoContent();
            */
            var administratorToDelete = await _administratorRepository.Delete(id);

            if (administratorToDelete == null)
            {
                return NotFound();
            }

            return Ok("Resource Deleted Succesfully");
        }

        private bool AdministratorExists(int id)
        {
            //return _context.Administrators.Any(e => e.Id == id);
            return _administratorRepository.Get(id) != null;
        }
    }
    
}
