using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApiAlura.Model;

namespace WebApiAlura.Data.Dtos.Cinemas
{
    public class CreateCinemaDTO
    {       
        public string Nome { get; set; }
        public int EnderecoId { get; set; }
        public int GerenteId { get; set; }
    }
}
