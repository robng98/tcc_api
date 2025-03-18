using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using tcc1_api.Dtos.Tankobon;
using tcc1_api.Models;

namespace tcc1_api.Mappers
{
    public static class TankobonMappers
    {
        public static TankobonDto ToTankobonDto(this Tankobon tankobon)
        {
            return new TankobonDto
            {
                Id = tankobon.Id,
                NumeroCapitulos = tankobon.NumeroCapitulos,
                EdicaoId = tankobon.EdicaoId,
                Edicao = tankobon.Edicao?.ToEdicaoDto()
            };
        }

        public static Tankobon ToTankobonFromCreateDTO(this CreateTankobonRequestDto tankobonDto, int edicaoId)
        {
            return new Tankobon
            {
                NumeroCapitulos = tankobonDto.NumeroCapitulos,
                EdicaoId = edicaoId
            };
        }
        
        public static Tankobon ToTankobonFromUpdateDTO(this UpdateTankobonRequestDto tankobonDto, int edicaoId)
        {
            return new Tankobon
            {
                NumeroCapitulos = tankobonDto.NumeroCapitulos,
                EdicaoId = edicaoId
            };
        }
    }
}