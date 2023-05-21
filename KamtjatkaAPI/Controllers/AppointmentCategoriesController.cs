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
    public class AppointmentCategoriesController : ControllerBase
    {
        private readonly IAppointmentCategoryRepository _appointmentCategoryRepository;

        public AppointmentCategoriesController(IAppointmentCategoryRepository appointmentCategoryRepository)
        {
            _appointmentCategoryRepository = appointmentCategoryRepository;
        }

        // GET: api/AppointmentCategories
        [HttpGet]
        public async Task<ActionResult<IEnumerable<AppointmentCategory>>> GetAppointmentCategories()
        {
            var appointmentCategories = await _appointmentCategoryRepository.Get();

            return Ok(appointmentCategories);
        }

        // GET: api/AppointmentCategories/5
        [HttpGet("{id}")]
        public async Task<ActionResult<AppointmentCategory>> GetAppointmentCategory(int id)
        {
            var appointmentCategory = await _appointmentCategoryRepository.Get(id);

            if (appointmentCategory == null)
            {
                return NotFound();
            }

            return appointmentCategory;
        }

        // PUT: api/AppointmentCategories/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAppointmentCategory(int id, AppointmentCategory appointmentCategory)
        {
            if (id != appointmentCategory.Id)
            {
                return BadRequest();
            }

            await _appointmentCategoryRepository.Update(appointmentCategory);
            
            return Ok("PUT successful");
        }

        // POST: api/AppointmentCategories
        [HttpPost]
        public async Task<ActionResult<AppointmentCategory>> PostAppointmentCategory(AppointmentCategory appointmentCategory)
        {
            var newAppointmentCategory = await _appointmentCategoryRepository.Create(appointmentCategory);

            return CreatedAtAction(nameof(GetAppointmentCategory), new { id = newAppointmentCategory.Id }, newAppointmentCategory);
        }

        // DELETE: api/AppointmentCategories/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAppointmentCategory(int id)
        {
            var appointmentCategoryToDelete = await _appointmentCategoryRepository.Delete(id);

            if (appointmentCategoryToDelete == null)
            {
                return NotFound();
            }

            return Ok("Resource Deleted Succesfully");
        }

        private bool AppointmentCategoryExists(int id)
        {
            return _appointmentCategoryRepository.Get(id) != null;
        }
    }
}
