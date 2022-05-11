using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using WebApiAlura.Model;

namespace WebApiAlura.Data.Dtos.Sessoes
{
    public class CreateSessaoDTO
    {
        [JsonIgnore]
        public Cinema Cinema { get; set; }
        [JsonIgnore]
        public Filme Filme { get; set; }
        public int FilmeId { get; set; }
        public int CinemaId { get; set; }
        public DateTime HorarioDeEncerramento { get; set; }
    }
}
