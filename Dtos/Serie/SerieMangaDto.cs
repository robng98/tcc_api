using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using tcc1_api.Dtos.Genero;
using tcc1_api.Dtos.Manga;

namespace tcc1_api.Dtos.Serie
{
    public class SerieMangaDto
    {
        public int Id { get; set; }
        public string EstadoPubAtual { get; set; } = string.Empty;
        public string NomeInter { get; set; } = string.Empty;
        public int CicloNum { get; set; }
        public List<GeneroDto> Generos { get; set; } = new List<GeneroDto>();
        // public List<EdicaoDto> Edicoes { get; set; } = new List<EdicaoDto>();
        public int NumEdicoes { get; set; }
        public MangaDto MangaStats { get; set; }
        public int EditoraId { get; set; }


    }
}