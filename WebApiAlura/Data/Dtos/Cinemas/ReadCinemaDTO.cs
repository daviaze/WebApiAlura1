using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApiAlura.Data.Dtos.Enderecos;
using WebApiAlura.Model;

namespace WebApiAlura.Data.Dtos.Cinemas
{
    public class ReadCinemaDTO
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public ReadEnderecoDTO Endereco { get; set; }
        public Gerente Gerente { get; set; }
    }
}
