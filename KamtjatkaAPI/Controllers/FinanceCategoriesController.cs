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
    public class FinanceCategoriesController : ControllerBase
    {
        //private readonly vujeeaxiContext _context;
        private readonly IFinanceCategoryRepository _financeCategoryRepository;

        /* public FinanceCategoriesController(vujeeaxiContext context)
         {
             _context = context;
         }
        */
        public FinanceCategoriesController(IFinanceCategoryRepository financeCategoryRepository)
        {
            _financeCategoryRepository = financeCategoryRepository;
        }

        // GET: api/FinanceCategories
        [HttpGet]
        public async Task<ActionResult<IEnumerable<FinanceCategory>>> GetFinanceCategories()
        {
            //return await _context.FinanceCategories.ToListAsync();
            var financeCategory = await _financeCategoryRepository.Get();
            return Ok(financeCategory);
        }

        // GET: api/FinanceCategories/5
        [HttpGet("{id}")]
        public async Task<ActionResult<FinanceCategory>> GetFinanceCategory(int id)
        {
            /*
            var financeCategory = await _context.FinanceCategories.FindAsync(id);

            if (financeCategory == null)
            {
                return NotFound();
            }

            return financeCategory;
            */
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
            /*
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
            */
            if (id != financeCategory.Id)
            {
                return BadRequest();
            }

            await _financeCategoryRepository.Update(financeCategory);

            return NoContent();
        }

        // POST: api/FinanceCategories
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<FinanceCategory>> PostFinanceCategory(FinanceCategory financeCategory)
        {
            /*
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
            */
            var newFinanceCategory = await _financeCategoryRepository.Create(financeCategory);
            return CreatedAtAction(nameof(GetFinanceCategory), new { id = newFinanceCategory.Id }, newFinanceCategory);
        }

        // DELETE: api/FinanceCategories/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteFinanceCategory(int id)
        {
            /*
            var financeCategory = await _context.FinanceCategories.FindAsync(id);
            if (financeCategory == null)
            {
                return NotFound();
            }

            _context.FinanceCategories.Remove(financeCategory);
            await _context.SaveChangesAsync();

            return NoContent();
            */
            var financeCategoryToDelete = await _financeCategoryRepository.Delete(id);

            if (financeCategoryToDelete == null)
            {
                return NotFound();
            }

            return (IActionResult)financeCategoryToDelete;
        }

        private bool FinanceCategoryExists(int id)
        {
            //return _context.FinanceCategories.Any(e => e.Id == id);
            return _financeCategoryRepository.Get(id) != null;
        }
    }
}
