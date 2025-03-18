using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace tcc1_api.Dtos.Contribuidor
{
    public class CreateContribuidorRequestDto
    {
        public string Genero { get; set; } = string.Empty;
        public string Nome { get; set; } = string.Empty;
        public DateTime DataNasc { get; set; }
    }
}