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
    public class AppointmentsController : ControllerBase
    {
        //private readonly vujeeaxiContext _context;
        private readonly IAppointmentRepository _appointmentRepository;

        /* public AppointmentsController(vujeeaxiContext context)
         {
             _context = context;
         }
        */

        public AppointmentsController(IAppointmentRepository appointmentRepository)
        {
            _appointmentRepository = appointmentRepository;
        }

        // GET: api/Appointments
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Appointment>>> GetAppointments()
        {
            //return await _context.Appointments.ToListAsync();
            var appointments = await _appointmentRepository.Get();
            return Ok(appointments);
        }

        // GET: api/Appointments/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Appointment>> GetAppointment(int id)
        {
            /*
            var appointment = await _context.Appointments.FindAsync(id);

            if (appointment == null)
            {
                return NotFound();
            }

            return appointment;
            */
            var appointment = await _appointmentRepository.Get(id);

            if (appointment == null)
            {
                return NotFound();
            }

            return appointment;
        }

        // PUT: api/Appointments/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAppointment(int id, Appointment appointment)
        {
            /*
            if (id != appointment.Id)
            {
                return BadRequest();
            }

            _context.Entry(appointment).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AppointmentExists(id))
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
            if (id != appointment.Id)
            {
                return BadRequest();
            }

            await _appointmentRepository.Update(appointment);

            return NoContent();
        }

        // POST: api/Appointments
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Appointment>> PostAppointment(Appointment appointment)
        {
            /*
            _context.Appointments.Add(appointment);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (AppointmentExists(appointment.Id))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetAppointment", new { id = appointment.Id }, appointment);
            */
            var newAppointment = await _appointmentRepository.Create(appointment);
            return CreatedAtAction(nameof(GetAppointment), new { id = newAppointment.Id }, newAppointment);
        }

        // DELETE: api/Appointments/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAppointment(int id)
        {
            /*
            var appointment = await _context.Appointments.FindAsync(id);
            if (appointment == null)
            {
                return NotFound();
            }

            _context.Appointments.Remove(appointment);
            await _context.SaveChangesAsync();

            return NoContent();
            */
            var appointmentToDelete = await _appointmentRepository.Delete(id);

            if (appointmentToDelete == null)
            {
                return NotFound();
            }

            return (IActionResult)appointmentToDelete;
        }

        private bool AppointmentExists(int id)
        {
            //return _context.Appointments.Any(e => e.Id == id);
            return _appointmentRepository.Get(id) != null;
        }
    }
}
