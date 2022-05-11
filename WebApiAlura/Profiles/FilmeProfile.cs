using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApiAlura.Data.Dtos;
using WebApiAlura.Data.Dtos.Cinemas;
using WebApiAlura.Data.Dtos.Enderecos;
using WebApiAlura.Data.Dtos.Gerentes;
using WebApiAlura.Data.Dtos.Sessoes;
using WebApiAlura.Model;

namespace WebApiAlura.Profiles
{
    public class FilmeProfile
    {
        public static MapperConfiguration RegisterMaps()
        {
            var mappingConfig = new MapperConfiguration(config =>
            {
                config.CreateMap<CreateFilmeDTO, Filme>();
                config.CreateMap<UpdateFilmeDTO, Filme>();
                config.CreateMap<Filme, ReadFilmeDTO>();

                config.CreateMap<CreateEnderecoDTO, Endereco>();
                config.CreateMap<UpdateEnderecoDTO, Endereco>();
                config.CreateMap<Endereco, ReadEnderecoDTO>();
                config.CreateMap<CreateCinemaDTO, Cinema>();
                config.CreateMap<UpdateCinemaDTO, Cinema>();
                config.CreateMap<Cinema, ReadCinemaDTO>();
                config.CreateMap<Gerente, ReadGerenteDTO>()
                .ForMember(gerente => gerente.Cinemas, opts => opts
                .MapFrom(gerente => gerente.Cinemas.Select(
                    c => new { c.Id, c.Nome, c.Endereco, c.EnderecoId }))
                );
                config.CreateMap<CreateGerenteDTO, Gerente>();
                config.CreateMap<UpdateGerenteDTO, Gerente>();
                config.CreateMap<CreateSessaoDTO, Sessao>();
                config.CreateMap<UpdateSessaoDTO, Sessao>();
                config.CreateMap<CreateSessaoDTO, ReadSessaoDTO>();
                config.CreateMap<Sessao, ReadSessaoDTO>()
                .ForMember(dto => dto.HorarioDeInicio, opts => 
                opts.MapFrom(dto => dto.HorarioDeEncerramento
                .AddMinutes(dto.Filme.Duracao * (-1))));




            });
            return mappingConfig;
        }
    }
}
