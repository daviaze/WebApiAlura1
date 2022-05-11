using AutoMapper;
using FluentResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApiAlura.Data;
using WebApiAlura.Data.Dtos.Cinemas;
using WebApiAlura.Model;
using WebApiAlura.Services;

namespace WebApiAlura.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CinemasController : ControllerBase
    {
        CinemaService _cinemaService;
        public CinemasController(CinemaService cinemaService)
        {
            _cinemaService = cinemaService;
        }

        [HttpGet]
        public IActionResult GetCinema([FromQuery] string nomeDoFilme)
        {
            List<ReadCinemaDTO> cinema = _cinemaService.GetCinema(nomeDoFilme);
            return Ok(cinema);
        }

        [HttpGet("id")]
        public IActionResult GetOneCinema(int id)
        {
            ReadCinemaDTO cinema = _cinemaService.getOneCinema(id);
            if (cinema != null) return Ok(cinema);
            return NotFound();
        }

        [HttpPost]
        public IActionResult AddCinema([FromBody] CreateCinemaDTO cinemaDTO)
        {
            ReadCinemaDTO cinema = _cinemaService.AddCinema(cinemaDTO);
            return CreatedAtAction(nameof(GetOneCinema), new { id = cinema.Id }, cinema);
        }

        [HttpPut("id")]
        public IActionResult EditCinema([FromBody] UpdateCinemaDTO cinemaDTO, int id)
        {
            Result resultado = _cinemaService.EditCinema(cinemaDTO, id);
            if (resultado == Result.Ok()) return NoContent();
            return NotFound();
        }

        [HttpDelete("id")]
        public IActionResult DeleteCinema(int id)
        {
            Result resultado = _cinemaService.DeleteCinema(id);
            if (resultado == Result.Ok()) return NoContent();
            return NotFound();
        }
    }
}
