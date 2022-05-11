using AutoMapper;
using FluentResults;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using UsuariosApi.Data.Requests;
using UsuariosApi.Dtos;
using UsuariosApi.Model;

namespace UsuariosApi.Services
{
    public class UsuarioService
    {
        IMapper _mapper;
        private UserManager<IdentityUser<int>> _userManager;
        EmailService _emailService;
        public UsuarioService(IMapper mapper, UserManager<IdentityUser<int>> userManager, EmailService emailService)
        {
            _mapper = mapper;
            _userManager = userManager;
            _emailService = emailService;
        }

        public Result CadastraUsuario(CreateUsuarioDTO createUsarioDTO)
        {
            Usuario usuario = _mapper.Map<Usuario>(createUsarioDTO);
            IdentityUser<int> usuarioIdentity = _mapper.Map<IdentityUser<int>>(usuario);
            Task<IdentityResult> resultadoIdentity = _userManager.CreateAsync(usuarioIdentity, createUsarioDTO.Password);
            if (resultadoIdentity.Result.Succeeded)
            {
                var code = _userManager.GenerateEmailConfirmationTokenAsync(usuarioIdentity).Result;
                var encondedCode = HttpUtility.UrlEncode(code);
                _emailService.EnviarEmail(new[] { usuarioIdentity.Email }, "Link de ativação", usuarioIdentity.Id, encondedCode);

                return Result.Ok().WithSuccess(code);
            }
            return Result.Fail("Falha ao cadastrar usuário");

        }

        public Result AtivaCadastro(AtivaCadastro ativaCadastro)
        {
            var user = _userManager.Users.FirstOrDefault(u => u.Id == ativaCadastro.UsuarioId);
            var confirm = _userManager.ConfirmEmailAsync(user, ativaCadastro.CodigoDeAtivacao).Result;
            if (confirm.Succeeded) return Result.Ok();
            return Result.Fail("Falha ao confirmar");
        }
    }
}
