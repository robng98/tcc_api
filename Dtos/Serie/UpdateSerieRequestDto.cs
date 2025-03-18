using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using tcc1_api.Models;

namespace tcc1_api.Dtos.Serie
{
    public class UpdateSerieRequestDto
    {
        public string EstadoPubAtual { get; set; } = string.Empty;
        public string NomeInter { get; set; } = string.Empty;
        public int CicloNum { get; set; }
        // public List<Genero> Generos { get; set; } = new List<Genero>();
    }
}