using AutoMapper;
using FluentResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApiAlura.Data;
using WebApiAlura.Data.Dtos.Gerentes;
using WebApiAlura.Model;
using WebApiAlura.Services;

namespace WebApiAlura.Controllers
{
    [ApiController]
    [Route("[controller]")]

    public class GerentesController : ControllerBase
    {
        GerenteService _gerenteService;
        public GerentesController(GerenteService gerenteService)
        {
            _gerenteService = gerenteService;
        }

        [HttpGet]
        public ActionResult GetGerente()
        {
            return Ok(_gerenteService.GetGerente());
        }

        [HttpGet("id")]
        public ActionResult GetOneGerente([FromQuery] int id)
        {
            ReadGerenteDTO gerente = _gerenteService.GetOneGerente(id);
            if (gerente is not null) return Ok(gerente);
            return NotFound();
        }
        [HttpPost]
        public ActionResult AddGerente([FromBody] CreateGerenteDTO createGerenteDTO)
        {
            ReadGerenteDTO gerente = _gerenteService.AddGerente(createGerenteDTO);
            return CreatedAtAction(nameof(GetOneGerente), new { id = gerente.Id }, gerente);
        }

        [HttpPut("id")]
        public ActionResult EditGerente([FromBody] UpdateGerenteDTO gerente, int id)
        {
            Result resultado = _gerenteService.EditGerente(gerente, id);
            if (resultado.IsSuccess) return NoContent();
            return NotFound();
        }

        [HttpDelete("id")]
        public ActionResult DeleteGerente([FromQuery] int id)
        {
            Result resultado = _gerenteService.DeleteGerente(id);
            if (resultado.IsSuccess) return NoContent();
            return NotFound();
        }
    }
}
