using AutoMapper;
using FluentResults;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApiAlura.Data;
using WebApiAlura.Data.Dtos;
using WebApiAlura.Model;

namespace WebApiAlura.Services
{
    public class FilmeService
    {
        private FilmeContext _context;
        private IMapper _mapper;
        public FilmeService(FilmeContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public List<ReadFilmeDTO> GetFilme(int? classificacaoetaria)
        {
            if (classificacaoetaria is null)
            {
                List<ReadFilmeDTO> readFilmeDTOs = _mapper.Map<List<ReadFilmeDTO>>(_context.Filmes.AsSplitQuery().ToList());
                return readFilmeDTOs;
            }

            List<Filme> filmes = _context.Filmes.AsSplitQuery().Where(c => c.ClassificacaoEtaria <= classificacaoetaria).ToList();
            if (filmes != null)
            {
                List<ReadFilmeDTO> readFilmeDTOs = _mapper.Map<List<ReadFilmeDTO>>(filmes);
                return readFilmeDTOs;
            }
            return null;
        }

        internal ReadFilmeDTO GetOneFilme(int id)
        {
            Filme filme = _context.Filmes.AsSplitQuery().FirstOrDefault(i => i.Id == id);

            if (filme != null)
            {
                ReadFilmeDTO n = _mapper.Map<ReadFilmeDTO>(filme);

                return n;
            }
            return null;
        }

        internal Result EditFilme(UpdateFilmeDTO filmeDTO, int id)
        {
            Filme filme = _context.Filmes.FirstOrDefault(i => i.Id == id);

            if (filme == null)
            {
                return Result.Fail("Filme não encontrado");
            }

            _mapper.Map(filmeDTO, filme);
            _context.SaveChanges();

            return Result.Ok();
        }

        internal Result DeleteFilme(int id)
        {
            Filme filme = _context.Filmes.FirstOrDefault(i => i.Id == id);

            if (filme == null)
            {
                return Result.Fail("Filme não encontrado");
            }

            _context.Remove(filme);
            _context.SaveChanges();

            return Result.Ok();
        }

        internal ReadFilmeDTO AddFilme(CreateFilmeDTO filmeDTO)
        {
            Filme filme = _mapper.Map<Filme>(filmeDTO);

            _context.Filmes.Add(filme);
            _context.SaveChanges();

            return _mapper.Map<ReadFilmeDTO>(filme);
        }
    }
}
