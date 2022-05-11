using AutoMapper;
using FluentResults;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UsuariosApi.Data.Requests;
using UsuariosApi.Model;

namespace UsuariosApi.Services
{
    public class LoginService
    {
        private SignInManager<IdentityUser<int>> _userManager;
        private TokenService _tokenService;
        public LoginService(SignInManager<IdentityUser<int>> userManager, TokenService tokenService)
        {
            _userManager = userManager;
            _tokenService = tokenService;
        }

        public Result EfetuaLogin(LoginRequest login)
        {
            var resultado = _userManager.PasswordSignInAsync(login.Username, login.Password, false, false);
            if (resultado.Result.Succeeded)
            {
                var identityUser = _userManager.UserManager.Users.FirstOrDefault(usuario =>
                usuario.NormalizedUserName == login.Username.ToUpper());

                Token token = _tokenService.CreateToken(identityUser);
                return Result.Ok().WithSuccess(token.Value);
            }
            return Result.Fail("O Login falhou");
        }

        public Result SolicitaResetSenha(SolicitaReset solicitaReseteSenha)
        {
            var identityUser = _userManager.UserManager.Users.
                FirstOrDefault(u => u.NormalizedEmail == solicitaReseteSenha.Email);

            if (identityUser != null)
            {
                string codigoDeVerificacao = _userManager.UserManager.GeneratePasswordResetTokenAsync(identityUser).Result;
                return Result.Ok().WithSuccess(codigoDeVerificacao);
            }
            return Result.Fail("Falha ao solicitar redefinição de senha");
        }
    }
}
