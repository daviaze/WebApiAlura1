using AutoMapper;
using FluentResults;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApiAlura.Data;
using WebApiAlura.Data.Dtos.Gerentes;
using WebApiAlura.Model;

namespace WebApiAlura.Services
{
    public class GerenteService
    {
        public FilmeContext _context;
        public IMapper _mapper;

        public GerenteService(FilmeContext filmeContext, IMapper mapper)
        {
            _context = filmeContext;
            _mapper = mapper;
        }

        public object GetGerente()
        {
            return _context.Gerentes.Include(g => g.Cinemas).AsSplitQuery().ToList();
        }

        public ReadGerenteDTO GetOneGerente(int id)
        {
            Gerente gerente = _context.Gerentes.Include(g => g.Cinemas).FirstOrDefault(g => g.Id == id);

            if (gerente == null)
            {
                return null;
            }
            ReadGerenteDTO g = _mapper.Map<ReadGerenteDTO>(gerente);

            return g;
        }

        public ReadGerenteDTO AddGerente(CreateGerenteDTO createGerenteDTO)
        {
            Gerente gerente = _mapper.Map<Gerente>(createGerenteDTO);
            _context.Gerentes.Add(gerente);
            _context.SaveChanges();
            return _mapper.Map<ReadGerenteDTO>(gerente);
        }

        public Result DeleteGerente(int id)
        {
            Gerente gerente = _context.Gerentes.AsSplitQuery().FirstOrDefault(g => g.Id == id);

            if (gerente == null)
            {
                return Result.Fail("Gerente não encontrado");
            }
            _context.Gerentes.Remove(gerente);
            _context.SaveChanges();
            return Result.Ok();
        }

        public Result EditGerente(UpdateGerenteDTO gerente, int id)
        {
            Gerente Gerente = _context.Gerentes.FirstOrDefault(i => i.Id == id);

            if (Gerente == null)
            {
                return Result.Fail("Gerente não encontrado");
            }

            _mapper.Map(gerente, Gerente);
            _context.SaveChanges();

            return Result.Ok();
        }
    }
}
