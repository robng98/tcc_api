using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace tcc1_api.Dtos.Editora
{
    public class CreateEditoraRequestDto
    {
        public DateTime AnoCriacao { get; set; }
        public string Nome { get; set; } = string.Empty;
        public string? Logo { get; set; } = string.Empty;
    }
}