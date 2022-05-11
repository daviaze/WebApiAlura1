using AutoMapper;
using FluentResults;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApiAlura.Data;
using WebApiAlura.Data.Dtos.Enderecos;
using WebApiAlura.Model;

namespace WebApiAlura.Services
{
    public class EnderecoService
    {
        private FilmeContext _context;
        private IMapper _mapper;
        public EnderecoService(FilmeContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public object GetEndereco()
        {
            List<Endereco> enderecoDTOs = _context.Enderecos.AsSplitQuery().ToList();
            return enderecoDTOs;
        }

        public ReadEnderecoDTO GetOneEndereco(int id)
        {
            Endereco ninja = _context.Enderecos.AsSplitQuery().FirstOrDefault(i => i.Id == id);

            if (ninja != null)
            {
                ReadEnderecoDTO n = _mapper.Map<ReadEnderecoDTO>(ninja);

                return n;
            }
            return null;
        }

        public ReadEnderecoDTO AddEndereco(CreateEnderecoDTO enderecoDTO)
        {
            Endereco endereco = _mapper.Map<Endereco>(enderecoDTO);

            _context.Enderecos.Add(endereco);
            _context.SaveChanges();
            return _mapper.Map<ReadEnderecoDTO>(endereco);
        }

        public Result EditEndereco(UpdateEnderecoDTO enderecoDTO, int id)
        {
            Endereco Endereco = _context.Enderecos.FirstOrDefault(i => i.Id == id);

            if (Endereco == null)
            {
                return Result.Fail("Endereco não encontrado");
            }

            _mapper.Map(enderecoDTO, Endereco);
            _context.SaveChanges();

            return Result.Ok();
        }

        public Result DeleteEndereco(int id)
        {
            Endereco Endereco = _context.Enderecos.FirstOrDefault(i => i.Id == id);

            if (Endereco == null)
            {
                return Result.Fail("Endereco não encontrado");
            }

            _context.Remove(Endereco);
            _context.SaveChanges();

            return Result.Ok();
        }
    }
}
