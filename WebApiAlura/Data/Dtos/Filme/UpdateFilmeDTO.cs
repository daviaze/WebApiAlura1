using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApiAlura.Data.Dtos
{
    public class UpdateFilmeDTO
    {
        public string Titulo { get; set; }
        public string Diretor { get; set; }
        public string Genero { get; set; }
        public string Duracao { get; set; }
        public int ClassificacaoEtaria { get; set; }

    }
}
