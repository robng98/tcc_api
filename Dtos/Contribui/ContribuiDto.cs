using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using tcc1_api.Dtos.Contribuidor;
using tcc1_api.Dtos.Edicao;
using tcc1_api.Dtos.Serie;
using tcc1_api.Models;

namespace tcc1_api.Dtos.Contribui
{
    public class ContribuiDto : ContribuidorDto
    {
        // public int ContribuidorId { get; set; }
        // public int SerieId { get; set; }
        public string Funcao { get; set; } = string.Empty;
        public List<EdicaoDto> Edicoes { get; set; } = new List<EdicaoDto>();
    }
}