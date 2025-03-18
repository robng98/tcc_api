using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using tcc1_api.Dtos.Edicao;
using tcc1_api.Dtos.Genero;
using tcc1_api.Dtos.Serie;
using tcc1_api.Models;

namespace tcc1_api.Dtos.Tankobon
{
    public class TankobonDto
    {
        public int Id { get; set; }
        public int EdicaoId { get; set; }
        public EdicaoDto? Edicao { get; set; }
        public int NumeroCapitulos { get; set; }
    }
}