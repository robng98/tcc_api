using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using tcc1_api.Dtos.Genero;
using tcc1_api.Dtos.Serie;
using tcc1_api.Models;

namespace tcc1_api.Dtos.Exemplar
{
    public class ExemplarDto
    {
        public int Id { get; set; }
        public string EstadoConservacao { get; set; } = string.Empty;
        public DateTime DataAquisicao { get; set; }
        public int EdicaoId { get; set; }
        public int ColecaoId { get; set; }
        public string SerieNome { get; set; } = string.Empty;
    }
}