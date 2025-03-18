using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using tcc1_api.Dtos.Serie;

namespace tcc1_api.Dtos.Genero
{
    public class GeneroDto
    {
        public int Id { get; set; }
        public string Tipo { get; set; } = string.Empty;
        public int SerieId { get; set; }
    }
}