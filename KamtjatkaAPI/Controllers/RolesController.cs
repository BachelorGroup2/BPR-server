using System.Collections.Generic;
using System.Threading.Tasks;
using KamtjatkaAPI.Models;
using KamtjatkaAPI.Repositories;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace KamtjatkaAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [EnableCors("AllowOrigin")]
    public class RolesController : ControllerBase
    {
        private readonly IRolesRepository _roleRepository;

        public RolesController(IRolesRepository roleRepository)
        {
            _roleRepository = roleRepository;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Roles>>> GetRoles()
        {
            var roles = await _roleRepository.Get();

            return Ok(roles);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Roles>> GetRole(int id)
        {
            var role = await _roleRepository.Get(id);

            if (role == null)
            {
                return NotFound();
            }

            return role;
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutRole(int id, Roles role)
        {
            if (id != role.Id)
            {
                return BadRequest();
            }

            await _roleRepository.Update(role);

            return Ok("PUT successfull");
        }

        [HttpPost]
        public async Task<ActionResult<Roles>> PostRole(Roles role)
        {
            var newRole = await _roleRepository.Create(role);

            return CreatedAtAction(nameof(GetRole), new { id = newRole.Id }, newRole);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRole(int id)
        {
            var roleToDelete = await _roleRepository.Delete(id);

            if (roleToDelete == null)
            {
                return NotFound();
            }

            return Ok("Role Deleted");
        }

      
    }
}
