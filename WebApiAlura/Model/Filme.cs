using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace WebApiAlura.Model
{
    public class Filme
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Seu filme precisa ter um título!")]
        public string Titulo { get; set; }
        public string Diretor { get; set; }
        public string Genero { get; set; }

        [Required(ErrorMessage = "Seu filme precisa ter uma duração!")]
        public int Duracao { get; set; }

        [MaxLength(18)]
        public int ClassificacaoEtaria { get; set; }

        [JsonIgnore]
        public virtual List<Sessao> Sessoes { get; set; }
    }
}
