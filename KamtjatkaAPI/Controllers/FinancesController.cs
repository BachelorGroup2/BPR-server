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
    public class FinancesController : ControllerBase
    {
        
        private readonly IFinanceRepository _financeRepository;

      
        public FinancesController(IFinanceRepository financeRepository)
        {
            _financeRepository = financeRepository;
        }

        // GET: api/Finances
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Finance>>> GetFinances()
        {
       
            var finances = await _financeRepository.GetFinances();
            return Ok(finances);
        }



        // GET: api/Finances/getData
        [Route("getData")]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<object>>> GetFinanceData()
        {

            var finances = await _financeRepository.GetInvoiceData();
            return Ok(finances);
        }

        // GET: api/Finances/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Finance>> GetFinance(int id)
        {
            
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
          
          
            if (id != finance.Id)
            {
                return BadRequest();
            }

            await _financeRepository.Update(finance);

            
            return Ok("PUT successfull");
        }

        // POST: api/Finances
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<List<Finance>>> PostFinance(IEnumerable<Finance> finances)
        {
            Console.WriteLine("SADASDSADSAD");

           
            foreach (var finance in finances)
            {
                Console.WriteLine("EACH ONE");
                var newFinance = await _financeRepository.Create(finance);
              
            }
            
            return Ok("Ok");
        }

        // DELETE: api/Finances/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteFinance(int id)
        {
           
            var financeToDelete = await _financeRepository.Delete(id);

            if (financeToDelete == null)
            {
                return NotFound();
            }

            return Ok("Resource Deleted Succesfully");
        }

        private bool FinanceExists(int id)
        {
            
            return _financeRepository.Get(id) != null;
        }
    }
}
