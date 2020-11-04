using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TicketSystemProject.Models;
using TicketSystemProject.Data;

namespace TicketSystemProject.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    public class TicketStatusController : Controller
    {
        private readonly TicketSystemProjectContext _context;

        public TicketStatusController(TicketSystemProjectContext context)
        {
            _context = context;
        }

        // GET: api/ticketstatus/values
        [HttpGet("values")]
        public IEnumerable<TicketStatusModel> TicketStatuses()
        {
            return _context.TicketStatuses;
        }

        // GET: api/ticketstatus/values/5
        [HttpGet("values/{id}")]
        public async Task<IActionResult> GetTicket([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var ticketStatusModel = await _context.TicketStatuses.SingleOrDefaultAsync(m => m.ID == id);

            if (ticketStatusModel == null)
            {
                return NotFound();
            }

            return Ok(ticketStatusModel);
        }

        // PUT: api/ticketstatus/values/5
        [HttpPut("values/{id}")]
        public async Task<IActionResult> PutTicket([FromRoute] int id, [FromBody] TicketStatusModel ticketStatusModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != ticketStatusModel.ID)
            {
                return BadRequest();
            }

            _context.Entry(ticketStatusModel).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TicketStatusExists(id))
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

        // POST: api/ticketstatus/values
        [HttpPost("values")]
        public async Task<IActionResult> PostTicket([FromBody] TicketStatusModel ticketStatusModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.TicketStatuses.Add(ticketStatusModel);
            await _context.SaveChangesAsync();

            // CreatedAtAction gives response 500. No idea why it happens so I skipped to just sending the correct response
            return StatusCode(201);
        }

        // DELETE: api/ticketstatus/values/5
        [HttpDelete("values/{id}")]
        public async Task<IActionResult> DeleteTicket([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var ticketStatusModel = await _context.TicketStatuses.SingleOrDefaultAsync(m => m.ID == id);
            if (ticketStatusModel == null)
            {
                return NotFound();
            }

            _context.TicketStatuses.Remove(ticketStatusModel);
            await _context.SaveChangesAsync();

            return Ok(ticketStatusModel);
        }

        private bool TicketStatusExists(int id)
        {
            return _context.TicketStatuses.Any(e => e.ID == id);
        }
    }
}
