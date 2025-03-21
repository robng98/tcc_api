using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using tcc1_api.Dtos.Serie;

namespace tcc1_api.Dtos.Editora
{
    public class EditoraDto
    {
        public int Id { get; set; }
        public DateTime AnoCriacao { get; set; }
        public string Nome { get; set; } = string.Empty;
        public string? Logo { get; set; } = string.Empty;
        public int TotalSeries { get; set; }
    }
}