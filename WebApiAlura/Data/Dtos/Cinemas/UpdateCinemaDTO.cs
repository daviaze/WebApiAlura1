using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApiAlura.Data.Dtos.Enderecos;
using WebApiAlura.Model;

namespace WebApiAlura.Data.Dtos.Cinemas
{
    public class UpdateCinemaDTO
    {
        public string Nome { get; set; }
        public CreateEnderecoDTO Endereco { get; set; }
    }
}
