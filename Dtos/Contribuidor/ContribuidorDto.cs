using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using tcc1_api.Dtos.Serie;
using tcc1_api.Models;

namespace tcc1_api.Dtos.Contribuidor
{
    public class ContribuidorDto
    {
        public int Id { get; set; }
        public string Genero { get; set; } = string.Empty;
        public string Nome { get; set; } = string.Empty;
        public DateTime DataNasc { get; set; }
        public List<SerieDto> Series { get; set; } = new List<SerieDto>();
        public string Foto { get; set; } = string.Empty;
        // public List<Contribui> Contribuicoes { get; set; } = new List<Contribui>();
    }
}