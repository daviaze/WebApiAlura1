using FluentResults;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UsuariosApi.Services
{
    public class LogoutService
    {
        private SignInManager<IdentityUser<int>> _userManager;

        public LogoutService(SignInManager<IdentityUser<int>> userManager)
        {
            _userManager = userManager;
        }

        public Result DeslogarUsuario()
        {
            var resultado = _userManager.SignOutAsync();
            if (resultado.IsCompletedSuccessfully) return Result.Ok();
            return Result.Fail("Logou falhou");

        }
    }
}
