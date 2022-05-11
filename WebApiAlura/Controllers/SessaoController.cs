using AutoMapper;
using FluentResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApiAlura.Data;
using WebApiAlura.Data.Dtos.Sessoes;
using WebApiAlura.Model;
using WebApiAlura.Services;

namespace WebApiAlura.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SessaoController : ControllerBase
    {
        SessaoService _sessaoService;
        public SessaoController(SessaoService sessaoService)
        {
            _sessaoService = sessaoService;
        }

        [HttpGet]
        public IActionResult GetSessao()
        {
            return Ok(_sessaoService.GetSessao());
        }

        [HttpGet("id")]
        public IActionResult GetOneSessao(int id)
        {
            ReadSessaoDTO sessao = _sessaoService.GetOneSessao(id);
            if (sessao is not null) return Ok(sessao);
            return NotFound();
        }

        [HttpPost]
        public IActionResult AddSessao([FromBody] CreateSessaoDTO sessaoDTO)
        {
            ReadSessaoDTO sessao = _sessaoService.AddSessao(sessaoDTO);
            return CreatedAtAction(nameof(GetOneSessao), new { id = sessao.Id }, sessao);
        }

        [HttpPut("id")]
        public IActionResult EditSessao([FromBody] UpdateSessaoDTO sessaoDTO, int id)
        {
            Result resultado = _sessaoService.EditSessao(sessaoDTO, id);
            if (resultado.IsSuccess) return NoContent();
            return NotFound();
        }

        [HttpDelete("id")]
        public IActionResult DeleteSessao(int id)
        {
            Result resultado = _sessaoService.DeleteSessao(id);
            if (resultado.IsSuccess) return NoContent();
            return NotFound();
        }
    }
}
