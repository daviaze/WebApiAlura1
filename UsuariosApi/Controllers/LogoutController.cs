using FluentResults;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UsuariosApi.Services;

namespace UsuariosApi.Controllers
{
    [ApiController]
    [Route("controller")]
    public class LogoutController : ControllerBase
    {
        LogoutService _logoutService;
        public LogoutController(LogoutService logoutService)
        {
            _logoutService = logoutService;
        }

        [HttpPost]
        public IActionResult Logout()
        {
            Result resultado = _logoutService.DeslogarUsuario();
            if (resultado.IsSuccess) return Ok("Deslogado com sucesso");
            return NotFound();
        }
    }
}
