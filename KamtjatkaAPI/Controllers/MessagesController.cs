using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using KamtjatkaAPI.Models;
using KamtjatkaAPI.Repositories;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace KamtjatkaAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [EnableCors("AllowOrigin")]
    public class MessagesController : ControllerBase
    {
        private readonly IMessagesRepository _messagesRepository;

        public RolesController(IMessagesRepository messagesRepository)
        {
            _messagesRepository = messagesRepository;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Messages>>> GetMessages()
        {
            var messages = await _messagesRepository.Get();
            return Ok(messages);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Messages>> GetMessage(int id)
        {
            var message = await _messagesRepository.Get(id);

            if (message == null)
            {
                return NotFound();
            }

            return message;
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutMessage(int id, Messages message)
        {
            if (id != message.Id)
            {
                return BadRequest();
            }

            await _messagesRepository.Update(message);

            //return NoContent();
            return Ok("PUT successfull");
        }

        [HttpPost]
        public async Task<ActionResult<Messages>> PostMessage(Messages message)
        {
            var newMessage = await _messagesRepository.Create(message);
            return CreatedAtAction(nameof(GetMessages), new { id = newMessage.Id }, newMessage);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMessage(int id)
        {
            var messageToDelete = await _messagesRepository.Delete(id);

            if (messageToDelete == null)
            {
                return NotFound();
            }

            return Ok("Message Deleted");
        }


    }
}
