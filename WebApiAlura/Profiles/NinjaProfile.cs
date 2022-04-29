using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApiAlura.Data.Dtos;
using WebApiAlura.Model;

namespace WebApiAlura.Profiles
{
    public class NinjaProfile
    {
        public static MapperConfiguration RegisterMaps()
        {
            var mappingConfig = new MapperConfiguration(config =>
            {
                config.CreateMap<CreateNinjaDTO, Ninja>();
                config.CreateMap<UpdateNinjaDTO, Ninja>();
                config.CreateMap<Ninja, ReadNinjaDTO>();
            });
            return mappingConfig;
        }
    }
}
