using AutoMapper;
using FluentResults;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApiAlura.Data;
using WebApiAlura.Data.Dtos.Sessoes;
using WebApiAlura.Model;

namespace WebApiAlura.Services
{
    public class SessaoService
    {
        public FilmeContext _context;
        public IMapper _mapper;
        public SessaoService(FilmeContext filmeContext, IMapper mapper)
        {
            _context = filmeContext;
            _mapper = mapper;
        }

        public List<ReadSessaoDTO> GetSessao()
        {
            List<Sessao> sessoes = _context.Sessoes
                .Include(sessao => sessao.Cinema)
                .Include(sessao => sessao.Filme)
                .AsSplitQuery()
                .ToList();

            List<ReadSessaoDTO> sessaoDTOs = _mapper.Map<List<ReadSessaoDTO>>(sessoes);
            return sessaoDTOs;
        }

        public ReadSessaoDTO GetOneSessao(int id)
        {
            Sessao sessao = _context.Sessoes
                .Include(sessao => sessao.Cinema)
                .Include(cinema => cinema.Filme)
                .AsSplitQuery()
                .FirstOrDefault(i => i.Id == id);

            if (sessao != null)
            {
                ReadSessaoDTO n = _mapper.Map<ReadSessaoDTO>(sessao);

                return n;
            }
            return null;
        }

        public ReadSessaoDTO AddSessao(CreateSessaoDTO sessaoDTO)
        {
            Sessao sessao = _mapper.Map<Sessao>(sessaoDTO);

            _context.Sessoes.Add(sessao);
            _context.SaveChanges();

            return _mapper.Map<ReadSessaoDTO>(sessaoDTO);
        }

        public Result DeleteSessao(int id)
        {
            Sessao sessao = _context.Sessoes.FirstOrDefault(i => i.Id == id);

            if (sessao == null)
            {
                return Result.Fail("Sessao não encontrada");
            }

            _context.Remove(sessao);
            _context.SaveChanges();

            return Result.Ok();
        }

        public Result EditSessao(UpdateSessaoDTO sessaoDTO, int id)
        {
            Sessao sessao = _context.Sessoes.FirstOrDefault(i => i.Id == id);

            if (sessao == null)
            {
                return Result.Fail("Sessao não encontrada");
            }

            _mapper.Map(sessaoDTO, sessao);
            _context.SaveChanges();

            return Result.Ok();
        }
    }
}
