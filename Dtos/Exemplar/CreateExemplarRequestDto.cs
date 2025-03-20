using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using tcc1_api.Dtos.Serie;
using tcc1_api.Models;

namespace tcc1_api.Dtos.Exemplar
{
    public class CreateExemplarRequestDto
    {
        public int EdicaoId { get; set; }
        public int ColecaoId { get; set; }
        public string EstadoConservacao { get; set; } = string.Empty;
        public DateTime DataAquisicao { get; set; }
    }
}