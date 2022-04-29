using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApiAlura.Data.Dtos
{
    public class UpdateNinjaDTO
    {
        public string Nome { get; set; }
        public string Cla { get; set; }
        public string Vila { get; set; }
        public string JutsuEspecializado { get; set; }
    }
}
