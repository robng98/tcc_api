using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using tcc1_api.Dtos.Contribuidor;

namespace tcc1_api.Dtos.Contribui
{
    public class CreateContribuiRequestDto
    {
        public int ContribuidorId { get; set; }
        public int EdicaoId { get; set; }
        public string Funcao { get; set; } = string.Empty;
    }
}