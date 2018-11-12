using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BBBWebApiCodeFirst.Models;

namespace BBBWebApiCodeFirst.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DaysController : ControllerBase
    {
        private readonly DataContext _context;

        public DaysController(DataContext context)
        {
            _context = context;
        }

        // GET: api/Days
        [HttpGet]
        public IEnumerable<Days> GetDayss()
        {
            return _context.Dayss;
        }

        // GET: api/Days/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetDays([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var days = await _context.Dayss.FindAsync(id);

            if (days == null)
            {
                return NotFound();
            }

            return Ok(days);
        }

        // PUT: api/Days/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutDays([FromRoute] int id, [FromBody] Days days)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != days.IdDay)
            {
                return BadRequest();
            }

            _context.Entry(days).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DaysExists(id))
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

        // POST: api/Days
        [HttpPost]
        public async Task<IActionResult> PostDays([FromBody] Days days)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Dayss.Add(days);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetDays", new { id = days.IdDay }, days);
        }

        // DELETE: api/Days/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDays([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var days = await _context.Dayss.FindAsync(id);
            if (days == null)
            {
                return NotFound();
            }

            _context.Dayss.Remove(days);
            await _context.SaveChangesAsync();

            return Ok(days);
        }

        private bool DaysExists(int id)
        {
            return _context.Dayss.Any(e => e.IdDay == id);
        }
    }
}