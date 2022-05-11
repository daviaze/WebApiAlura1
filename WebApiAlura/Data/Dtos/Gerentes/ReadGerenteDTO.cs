using System.Collections.Generic;
using WebApiAlura.Model;

namespace WebApiAlura.Data.Dtos.Gerentes
{
    public class ReadGerenteDTO
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public virtual object Cinemas { get; set; }
    }
}
