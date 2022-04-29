using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApiAlura.Data;
using WebApiAlura.Data.Dtos;
using WebApiAlura.Model;

namespace WebApiAlura.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class NinjaController : ControllerBase
    {
        private NinjaContext _context;
        private IMapper _mapper;
        public NinjaController(NinjaContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
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
                ReadNinjaDTO n = _mapper.Map<ReadNinjaDTO>(ninja);

                return Ok(n);
            }
            return NotFound();
        }

        [HttpPost]
        public IActionResult AddNinja([FromBody] CreateNinjaDTO ninjaDTO)
        {
            Ninja ninja = _mapper.Map<Ninja>(ninjaDTO);

            _context.Ninjas.Add(ninja);
            _context.SaveChanges();
            return CreatedAtAction(nameof(GetOneNinja), new { id = ninja.Id }, ninja);
        }

        [HttpPut("{id}")]
        public IActionResult EditNinja([FromBody] UpdateNinjaDTO ninjaDTO, int id)
        {
            Ninja ninja = _context.Ninjas.FirstOrDefault(i => i.Id == id);

            if (ninja == null)
            {
                return NotFound();
            }

            _mapper.Map(ninjaDTO, ninja);
            _context.SaveChanges();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteNinja(int id)
        {
            Ninja ninja = _context.Ninjas.FirstOrDefault(i => i.Id == id);

            if (ninja == null)
            {
                return NotFound();
            }

            _context.Remove(ninja);
            _context.SaveChanges();

            return NoContent();
        }


    }
}
