using AutoMapper;
using FluentResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using WebApiAlura.Data;
using WebApiAlura.Data.Dtos;
using WebApiAlura.Model;
using WebApiAlura.Services;

namespace WebApiAlura.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class FilmesController : ControllerBase
    {
        FilmeService _filmeservice;
        public FilmesController(FilmeService filmeservice)
        {
            _filmeservice = filmeservice;
        }

        [HttpGet]
        public IActionResult GetFilme([FromQuery] int? classificacaoetaria = null)
        {
            List<ReadFilmeDTO> filmes = _filmeservice.GetFilme(classificacaoetaria);
            if (filmes != null) return Ok(filmes);
            return NotFound();
        }

        [HttpGet("id")]
        public IActionResult GetOneFilme(int id)
        {
            ReadFilmeDTO filme = _filmeservice.GetOneFilme(id);
            if (filme != null) return Ok(filme);
            return NotFound();
        }

        [HttpPost]
        public IActionResult AddFilme([FromBody] CreateFilmeDTO filmeDTO)
        {
            ReadFilmeDTO filme = _filmeservice.AddFilme(filmeDTO);
            return CreatedAtAction(nameof(GetOneFilme), new { id = filme.Id }, filme);
        }

        [HttpPut("id")]
        public IActionResult EditFilme([FromBody] UpdateFilmeDTO filmeDTO, int id)
        {
            Result resultado = _filmeservice.EditFilme(filmeDTO, id);
            if (resultado == Result.Ok()) return NoContent();
            return NotFound();
        }

        [HttpDelete("id")]
        public IActionResult DeleteFilme(int id)
        {
            Result resultado = _filmeservice.DeleteFilme(id);
            if (resultado == Result.Ok()) return NoContent();
            return NotFound();
        }


    }
}
