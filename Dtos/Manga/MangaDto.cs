using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using tcc1_api.Dtos.Genero;
using tcc1_api.Dtos.Serie;
using tcc1_api.Models;

namespace tcc1_api.Dtos.Manga
{
    public class MangaDto
    {
        public int Id { get; set; }
        public string NomeJap { get; set; } = string.Empty;
        public string Demografia { get; set; } = string.Empty;
        public int SerieId { get; set; }
        // public SerieDto? Serie { get; set; }
    }
}