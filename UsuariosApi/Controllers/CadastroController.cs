using FluentResults;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UsuariosApi.Data.Requests;
using UsuariosApi.Dtos;
using UsuariosApi.Services;

namespace UsuariosApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CadastroController : ControllerBase
    {
        UsuarioService _usuarioService;
        public CadastroController(UsuarioService usuarioService)
        {
            _usuarioService = usuarioService;
        }

        [HttpPost]
        public IActionResult AddCadastro (CreateUsuarioDTO createUsarioDTO)
        {
            Result resultado = _usuarioService.CadastraUsuario(createUsarioDTO);
            return Ok(resultado.Successes[0]);
        }

        [HttpGet("/ativa")]
        public IActionResult AtivaCadastro ([FromQuery] AtivaCadastro ativaCadastro)
        {
            Result resultado = _usuarioService.AtivaCadastro(ativaCadastro);
            if (resultado.IsSuccess) return Ok();
            return StatusCode(500);
        }

    }
}
