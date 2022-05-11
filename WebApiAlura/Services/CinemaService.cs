using AutoMapper;
using FluentResults;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApiAlura.Data;
using WebApiAlura.Data.Dtos.Cinemas;
using WebApiAlura.Model;

namespace WebApiAlura.Services
{
    public class CinemaService
    {
        private FilmeContext _context;
        private IMapper _mapper;
        public CinemaService(FilmeContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public List<ReadCinemaDTO> GetCinema(string nomeDoFilme)
        {
            List<Cinema> cinemas = _context.Cinemas.ToList();

            if (cinemas == null)
            {
                return null;
            }

            if (!string.IsNullOrEmpty(nomeDoFilme))
            {
                IEnumerable<Cinema> query = from cinema in cinemas
                                            where cinema.Sessoes.Any(sessao =>
                                            sessao.Filme.Titulo == nomeDoFilme)
                                            select cinema;

                cinemas = query.ToList();
            }

            List<ReadCinemaDTO> readDto = _mapper.Map<List<ReadCinemaDTO>>(cinemas);

            return readDto;
        }

        internal ReadCinemaDTO AddCinema(CreateCinemaDTO cinemaDTO)
        {
            Cinema cinema = _mapper.Map<Cinema>(cinemaDTO);

            _context.Cinemas.Add(cinema);
            _context.SaveChanges();
            return _mapper.Map<ReadCinemaDTO>(cinema);

        }

        public ReadCinemaDTO getOneCinema(int id)
        {
            Cinema cinema = _context.Cinemas.Include(cinema => cinema.Endereco)
    .Include(cinema => cinema.Gerente)
    .AsSplitQuery()
    .FirstOrDefault(i => i.Id == id);

            if (cinema != null)
            {
                ReadCinemaDTO n = _mapper.Map<ReadCinemaDTO>(cinema);

                return n;
            }
            return null;
        }

        internal Result DeleteCinema(int id)
        {
            Cinema cinema = _context.Cinemas.FirstOrDefault(i => i.Id == id);

            if (cinema == null)
            {
                return Result.Fail("Cinema não encontrado");
            }

            _context.Remove(cinema);
            _context.SaveChanges();

            return Result.Ok();
        }

        internal Result EditCinema(UpdateCinemaDTO cinemaDTO, int id)
        {
            Cinema cinema = _context.Cinemas.FirstOrDefault(i => i.Id == id);

            if (cinema == null)
            {
                return Result.Fail("Cinema não encontrado");
            }

            _mapper.Map(cinemaDTO, cinema);
            _context.SaveChanges();

            return Result.Ok();
        }
    }
}
