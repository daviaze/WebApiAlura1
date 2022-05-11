using FluentResults;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UsuariosApi.Data.Requests;
using UsuariosApi.Services;

namespace UsuariosApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class LoginController : ControllerBase
    {
        private LoginService _loginService;

        public LoginController(LoginService loginService)
        {
            _loginService = loginService;
        }
        [HttpPost]
        public IActionResult Login(LoginRequest loginRequest)
        {
            Result resultado = _loginService.EfetuaLogin(loginRequest);
            if (resultado.IsSuccess) return Ok(resultado.Successes[0]);
            return Unauthorized(resultado.Errors);
        }

        [HttpPost("/reset-senha")]
        public IActionResult SolicitaResetSenha(SolicitaReset solicitaReseteSenha)
        {
            Result resultado = _loginService.SolicitaResetSenha(solicitaReseteSenha);
            if (resultado.IsSuccess) return Ok(resultado.Successes[0]);
            return Unauthorized(resultado.Errors);
        }
    }
}
