using AutoMapper;
using FluentResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApiAlura.Data;
using WebApiAlura.Data.Dtos;
using WebApiAlura.Data.Dtos.Enderecos;
using WebApiAlura.Model;
using WebApiAlura.Services;

namespace WebApiAlura.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class EnderecosController : ControllerBase
    {
        EnderecoService _enderecoService;
        public EnderecosController(EnderecoService enderecoService)
        {
            _enderecoService = enderecoService;
        }

        [HttpGet]
        public IActionResult GetEndereco()
        {
            return Ok(_enderecoService.GetEndereco());
        }

        [HttpGet("id")]
        public IActionResult GetOneEndereco(int id)
        {
            ReadEnderecoDTO endereco = _enderecoService.GetOneEndereco(id);
            if (endereco != null) return Ok(endereco);
            return NotFound();
        }

        [HttpPost]
        public IActionResult AddEndereco([FromBody] CreateEnderecoDTO enderecoDTO)
        {
            ReadEnderecoDTO endereco = _enderecoService.AddEndereco(enderecoDTO);
            return CreatedAtAction(nameof(GetOneEndereco), new { id = endereco.Id }, endereco);
        }

        [HttpPut("id")]
        public IActionResult EditEndereco([FromBody] UpdateEnderecoDTO enderecoDTO, int id)
        {
            Result resultado = _enderecoService.EditEndereco(enderecoDTO, id);
            if (resultado == Result.Ok()) return NoContent();
            return NotFound();
        }

        [HttpDelete("id")]
        public IActionResult DeleteEndereco(int id)
        {
            Result resultado = _enderecoService.DeleteEndereco(id);
            if (resultado.IsSuccess) return NoContent();
            return NotFound();
        }
    }
}
