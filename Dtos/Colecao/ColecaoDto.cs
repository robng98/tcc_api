using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using tcc1_api.Dtos.Exemplar;

namespace tcc1_api.Dtos.Colecao
{
    public class ColecaoDto
    {
        public int Id { get; set; }
        public string NomeColecao { get; set; } = string.Empty;
        public List<ExemplarDto> Exemplares { get; set; } = new List<ExemplarDto>();

    }
}