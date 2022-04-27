using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApiAlura.Data;
using WebApiAlura.Model;

namespace WebApiAlura.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NinjasController : ControllerBase
    {
        private readonly NinjaContext _context;

        public NinjasController(NinjaContext context)
        {
            _context = context;
        }

        // GET: api/Ninjas
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Ninja>>> GetNinjas()
        {
            return await _context.Ninjas.ToListAsync();
        }

        // GET: api/Ninjas/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Ninja>> GetNinja(int id)
        {
            var ninja = await _context.Ninjas.FindAsync(id);

            if (ninja == null)
            {
                return NotFound();
            }

            return ninja;
        }

        // PUT: api/Ninjas/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutNinja(int id, Ninja ninja)
        {
            if (id != ninja.Id)
            {
                return BadRequest();
            }

            _context.Entry(ninja).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!NinjaExists(id))
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

        // POST: api/Ninjas
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Ninja>> PostNinja(Ninja ninja)
        {
            _context.Ninjas.Add(ninja);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetNinja", new { id = ninja.Id }, ninja);
        }

        // DELETE: api/Ninjas/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteNinja(int id)
        {
            var ninja = await _context.Ninjas.FindAsync(id);
            if (ninja == null)
            {
                return NotFound();
            }

            _context.Ninjas.Remove(ninja);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool NinjaExists(int id)
        {
            return _context.Ninjas.Any(e => e.Id == id);
        }
    }
}
