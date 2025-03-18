using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using tcc1_api.Dtos.Serie;
using tcc1_api.Models;

namespace tcc1_api.Dtos.Edicao
{
    public class CreateEdicaoRequestDto
    {
        public string FotoCapa { get; set; } = string.Empty;
        public string Numero { get; set; } = string.Empty;
        public string UnMonetaria { get; set; } = string.Empty;
        public decimal Preco { get; set; }
        public DateTime DataLancamento { get; set; }
    }
}