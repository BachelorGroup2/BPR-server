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
    public class FinancesController : ControllerBase
    {
        //private readonly vujeeaxiContext _context;
        private readonly IFinanceRepository _financeRepository;

        /* public FinancesController(vujeeaxiContext context)
         {
             _context = context;
         }
        */
        public FinancesController(IFinanceRepository financeRepository)
        {
            _financeRepository = financeRepository;
        }

        // GET: api/Finances
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Finance>>> GetFinances()
        {
            //return await _context.Finances.ToListAsync();
            var finances = await _financeRepository.Get();
            return Ok(finances);
        }

        // GET: api/Finances/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Finance>> GetFinance(int id)
        {
            /*
            var finance = await _context.Finances.FindAsync(id);

            if (finance == null)
            {
                return NotFound();
            }

            return finance;
            */
            var finances = await _financeRepository.Get(id);

            if (finances == null)
            {
                return NotFound();
            }

            return finances;
        }

        // PUT: api/Finances/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutFinance(int id, Finance finance)
        {
            /*
            if (id != finance.Id)
            {
                return BadRequest();
            }

            _context.Entry(finance).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!FinanceExists(id))
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
            if (id != finance.Id)
            {
                return BadRequest();
            }

            await _financeRepository.Update(finance);

            return NoContent();
        }

        // POST: api/Finances
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Finance>> PostFinance(Finance finance)
        {
            /*
            _context.Finances.Add(finance);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (FinanceExists(finance.Id))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetFinance", new { id = finance.Id }, finance);
            */
            var newFinance = await _financeRepository.Create(finance);
            return CreatedAtAction(nameof(GetFinance), new { id = newFinance.Id }, newFinance);
        }

        // DELETE: api/Finances/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteFinance(int id)
        {
            /*
            var finance = await _context.Finances.FindAsync(id);
            if (finance == null)
            {
                return NotFound();
            }

            _context.Finances.Remove(finance);
            await _context.SaveChangesAsync();

            return NoContent();
            */
            var financeToDelete = await _financeRepository.Delete(id);

            if (financeToDelete == null)
            {
                return NotFound();
            }

            return (IActionResult)financeToDelete;
        }

        private bool FinanceExists(int id)
        {
            //return _context.Finances.Any(e => e.Id == id);
            return _financeRepository.Get(id) != null;
        }
    }
}
