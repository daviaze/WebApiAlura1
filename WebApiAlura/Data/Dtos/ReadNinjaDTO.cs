﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebApiAlura.Data.Dtos
{
    public class ReadNinjaDTO
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Seu ninja precisa ter um nome!")]
        public string Nome { get; set; }
        public string Cla { get; set; }
        public string Vila { get; set; }

        [Required(ErrorMessage = "Seu ninja precisa ter um jutsu especializado!")]
        public string JutsuEspecializado { get; set; }

        public DateTime HoraConsulta { get; set; }
    }
}