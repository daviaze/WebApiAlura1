using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApiAlura.Model;

namespace WebApiAlura.Data.Dtos.Gerentes
{
    public class UpdateGerenteDTO
    {
        public string Nome { get; set; }
        public virtual List<Cinema> Cinemas { get; set; }
    }
}
