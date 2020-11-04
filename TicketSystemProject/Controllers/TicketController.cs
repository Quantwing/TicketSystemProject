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
    public class TicketController : Controller
    {
        private readonly TicketSystemProjectContext _context;

        public TicketController(TicketSystemProjectContext context)
        {
            _context = context;
        }

        // GET: api/ticket/values
        [HttpGet("values")]
        public IEnumerable<TicketModel> Tickets()
        {
            return _context.Tickets;
        }

        // GET: api/ticket/values/5
        [HttpGet("values/{id}")]
        public async Task<IActionResult> GetTicket([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var ticketModel = await _context.Tickets.SingleOrDefaultAsync(m => m.ID == id);

            if (ticketModel == null)
            {
                return NotFound();
            }

            return Ok(ticketModel);
        }

        // PUT: api/ticket/values/5
        [HttpPut("values/{id}")]
        public async Task<IActionResult> PutTicket([FromRoute] int id, [FromBody] TicketModel ticketModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != ticketModel.ID)
            {
                return BadRequest();
            }

            _context.Entry(ticketModel).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TicketExists(id))
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

        // POST: api/ticket/values
        [HttpPost("values")]
        public async Task<IActionResult> PostTicket([FromBody] TicketModel ticketModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Tickets.Add(ticketModel);
            await _context.SaveChangesAsync();

            // CreatedAtAction gives response 500. No idea why it happens so I skipped to just sending the correct response
            return StatusCode(201);
        }

        // DELETE: api/ticket/values/5
        [HttpDelete("values/{id}")]
        public async Task<IActionResult> DeleteTicket([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var ticketModel = await _context.Tickets.SingleOrDefaultAsync(m => m.ID == id);
            if (ticketModel == null)
            {
                return NotFound();
            }

            _context.Tickets.Remove(ticketModel);
            await _context.SaveChangesAsync();

            return Ok(ticketModel);
        }

        private bool TicketExists(int id)
        {
            return _context.Tickets.Any(e => e.ID == id);
        }
    }
}
