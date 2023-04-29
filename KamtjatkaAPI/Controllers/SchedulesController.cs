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
    public class SchedulesController : ControllerBase
    {
        // private readonly vujeeaxiContext _context;
        private readonly IScheduleRepository _scheduleRepository;

        /* public SchedulesController(vujeeaxiContext context)
         {
             _context = context;
         }
        */

        public SchedulesController(IScheduleRepository scheduleRepository)
        {
            _scheduleRepository = scheduleRepository;
        }

        // GET: api/Schedules
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Schedule>>> GetSchedules()
        {
            //return await _context.Schedules.ToListAsync();
            var schedule = await _scheduleRepository.Get();
            return Ok(schedule);
        }

        // GET: api/Schedules/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Schedule>> GetSchedule(int id)
        {
            /*var schedule = await _context.Schedules.FindAsync(id);

            if (schedule == null)
            {
                return NotFound();
            }

            return schedule;
            */

            var schedule = await _scheduleRepository.Get(id);

            if (schedule == null)
            {
                return NotFound();
            }

            return schedule;
        }

        // PUT: api/Schedules/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSchedule(int id, Schedule schedule)
        {
            /*
            if (id != schedule.Id)
            {
                return BadRequest();
            }

            _context.Entry(schedule).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ScheduleExists(id))
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
            if (id != schedule.Id)
            {
                return BadRequest();
            }

            await _scheduleRepository.Update(schedule);

            return NoContent();
        }

        // POST: api/Schedules
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Schedule>> PostSchedule(Schedule schedule)
        {
            /*
            _context.Schedules.Add(schedule);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (ScheduleExists(schedule.Id))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetSchedule", new { id = schedule.Id }, schedule);
            */
            var newSchedule = await _scheduleRepository.Create(schedule);
            return CreatedAtAction(nameof(GetSchedule), new { id = newSchedule.Id }, newSchedule);
        }

        // DELETE: api/Schedules/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSchedule(int id)
        {
            /*
            var schedule = await _context.Schedules.FindAsync(id);
            if (schedule == null)
            {
                return NotFound();
            }

            _context.Schedules.Remove(schedule);
            await _context.SaveChangesAsync();

            return NoContent();
            */
            var scheduleToDelete = await _scheduleRepository.Delete(id);

            if (scheduleToDelete == null)
            {
                return NotFound();
            }

            return (IActionResult)scheduleToDelete;
        }

        private bool ScheduleExists(int id)
        {
            //return _context.Schedules.Any(e => e.Id == id);
            return _scheduleRepository.Get(id) != null;
        }
    }
}
