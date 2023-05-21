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
    public class AdministratorsController : ControllerBase
    {
        private readonly IAdministratorRepository _administratorRepository;
      
        public AdministratorsController(IAdministratorRepository administratorRepository)
        {
            _administratorRepository = administratorRepository;
        }

        // GET: api/Administrators
        [HttpGet]
        [EnableCors("AllowOrigin")]
        public async Task<ActionResult<IEnumerable<Administrator>>> GetAdministrators()
        {
            var administrators = await _administratorRepository.Get();

            return Ok(administrators);
        }

        // GET: api/Administrators/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Administrator>> GetAdministrator(int id)
        {
            var administrator = await _administratorRepository.Get(id);

            if (administrator == null)
            {
                return NotFound();
            }

            return administrator;
        }

        // PUT: api/Administrators/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAdministrator(int id, Administrator administrator)
        {
            if (id != administrator.Id)
            {
                return BadRequest();
            }

            await _administratorRepository.Update(administrator);
           
            return Ok("PUT successfull");
        }

        // POST: api/Administrators
        [HttpPost]
        public async Task<ActionResult<Administrator>> PostAdministrator(Administrator administrator)
        {
            var newAdministrator = await _administratorRepository.Create(administrator);

            return CreatedAtAction(nameof(GetAdministrator), new { id = newAdministrator.Id }, newAdministrator);
        }

        // DELETE: api/Administrators/5
        [HttpDelete("{id}")]
        [EnableCors("AllowOrigin")]
        public async Task<IActionResult> DeleteAdministrator(int id)
        {
            var administratorToDelete = await _administratorRepository.Delete(id);

            if (administratorToDelete == null)
            {
                return NotFound();
            }

            return Ok("Resource Deleted Succesfully");
        }

        private bool AdministratorExists(int id)
        {
            return _administratorRepository.Get(id) != null;
        }
    }
    
}
