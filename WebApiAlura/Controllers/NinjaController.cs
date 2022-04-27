using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApiAlura.Data;
using WebApiAlura.Model;

namespace WebApiAlura.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class NinjaController : ControllerBase
    {
        private NinjaContext _context;
        public NinjaController(NinjaContext context)
        {
            _context = context;
        }

        [HttpPost]
        public IActionResult AddNinja([FromBody] Ninja ninja)
        {
            _context.Ninjas.Add(ninja);
            _context.SaveChanges();
            return CreatedAtAction(nameof(GetOneNinja), new { id = ninja.Id}, ninja);
        }

        [HttpGet]
        public IActionResult GetNinja()
        {
            return Ok(_context.Ninjas.ToList());
        }

        [HttpGet("id")]
        public IActionResult GetOneNinja(int id)
        {
            Ninja ninja = _context.Ninjas.FirstOrDefault(i => i.Id == id);

            if (ninja != null)
            {
                return Ok(ninja);
            }
            return NotFound();
        }
    }
}
