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
    public class FinanceCategoriesController : ControllerBase
    {
        private readonly vujeeaxiContext _context;

        public FinanceCategoriesController(vujeeaxiContext context)
        {
            _context = context;
        }

        // GET: api/FinanceCategories
        [HttpGet]
        public async Task<ActionResult<IEnumerable<FinanceCategory>>> GetFinanceCategories()
        {
            return await _context.FinanceCategories.ToListAsync();
        }

        // GET: api/FinanceCategories/5
        [HttpGet("{id}")]
        public async Task<ActionResult<FinanceCategory>> GetFinanceCategory(int id)
        {
            var financeCategory = await _context.FinanceCategories.FindAsync(id);

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

            _context.Entry(financeCategory).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!FinanceCategoryExists(id))
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

        // POST: api/FinanceCategories
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<FinanceCategory>> PostFinanceCategory(FinanceCategory financeCategory)
        {
            _context.FinanceCategories.Add(financeCategory);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (FinanceCategoryExists(financeCategory.Id))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetFinanceCategory", new { id = financeCategory.Id }, financeCategory);
        }

        // DELETE: api/FinanceCategories/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteFinanceCategory(int id)
        {
            var financeCategory = await _context.FinanceCategories.FindAsync(id);
            if (financeCategory == null)
            {
                return NotFound();
            }

            _context.FinanceCategories.Remove(financeCategory);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool FinanceCategoryExists(int id)
        {
            return _context.FinanceCategories.Any(e => e.Id == id);
        }
    }
}
