using AutoMapper;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UsuariosApi.Dtos;
using UsuariosApi.Model;

namespace UsuariosApi.Profiles
{
    public class UsuarioProfile
    {
        public static MapperConfiguration RegisterMaps()
        {
            var mappingConfig = new MapperConfiguration(config =>
            {
                config.CreateMap<CreateUsuarioDTO, Usuario>();
                config.CreateMap<Usuario, IdentityUser<int>>();


            });
            return mappingConfig;
        }
    }
}
