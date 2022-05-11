using System.Collections.Generic;
using System.Text.Json.Serialization;
using WebApiAlura.Model;

namespace WebApiAlura.Data.Dtos.Gerentes
{
    public class CreateGerenteDTO
    {
        public string Nome { get; set; }

        [JsonIgnore]
        public virtual List<Cinema> Cinemas { get; set; }
    }
}
