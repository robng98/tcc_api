using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using tcc1_api.Models;

namespace tcc1_api.Dtos.Manga
{
    public class UpdateMangaRequestDto
    {
        public string NomeJap { get; set; } = string.Empty;
        public string Demografia { get; set; } = string.Empty;
    }
}