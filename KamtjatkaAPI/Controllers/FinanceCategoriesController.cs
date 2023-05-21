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
    public class FinanceCategoriesController : ControllerBase
    {
        private readonly IFinanceCategoryRepository _financeCategoryRepository;
      
        public FinanceCategoriesController(IFinanceCategoryRepository financeCategoryRepository)
        {
            _financeCategoryRepository = financeCategoryRepository;
        }

        // GET: api/FinanceCategories
        [HttpGet]
        public async Task<ActionResult<IEnumerable<FinanceCategory>>> GetFinanceCategories()
        {
            var financeCategory = await _financeCategoryRepository.Get();

            return Ok(financeCategory);
        }

        // GET: api/FinanceCategories/5
        [HttpGet("{id}")]
        public async Task<ActionResult<FinanceCategory>> GetFinanceCategory(int id)
        {
            var financeCategory = await _financeCategoryRepository.Get(id);

            if (financeCategory == null)
            {
                return NotFound();
            }

            return financeCategory;
        }

        // PUT: api/FinanceCategories/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutFinanceCategory(int id, FinanceCategory financeCategory)
        {
            if (id != financeCategory.Id)
            {
                return BadRequest();
            }

            await _financeCategoryRepository.Update(financeCategory);
           
            return Ok("PUT successfull");
        }

        // POST: api/FinanceCategories
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<FinanceCategory>> PostFinanceCategory(FinanceCategory financeCategory)
        {
            var newFinanceCategory = await _financeCategoryRepository.Create(financeCategory);

            return CreatedAtAction(nameof(GetFinanceCategory), new { id = newFinanceCategory.Id }, newFinanceCategory);
        }

        // DELETE: api/FinanceCategories/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteFinanceCategory(int id)
        {
            var financeCategoryToDelete = await _financeCategoryRepository.Delete(id);

            if (financeCategoryToDelete == null)
            {
                return NotFound();
            }

            return Ok("Resource Deleted Succesfully");
        }

        private bool FinanceCategoryExists(int id)
        {
            return _financeCategoryRepository.Get(id) != null;
        }
    }
}
