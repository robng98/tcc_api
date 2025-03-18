using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using tcc1_api.Dtos.Contribui;
using tcc1_api.Models;

namespace tcc1_api.Mappers
{
    public static class ContribuiMappers
    {
        public static ContribuiDto ToContribuiDto(this Contribui contribuidor)
        {
            return new ContribuiDto
            {
                // ContribuidorId = contribuidor.ContribuidorId,
                // SerieId = contribuidor.SerieId,
                Funcao = contribuidor.Funcao
            };
        }

        public static Contribui ToContribuiFromCreateContribuiDTO(this CreateContribuiRequestDto contribuidorDto)
        {
            return new Contribui
            {
                // ContribuidorId = contribuidorDto.ContribuidorId,
                // SerieId = contribuidorDto.SerieId,
                Funcao = contribuidorDto.Funcao
            };
        }

        public static Contribui ToContribuiFromUpdateContribuiDTO(this UpdateContribuiRequestDto contribuidorDto)
        {
            return new Contribui
            {
                // ContribuidorId = contribuidorDto.ContribuidorId,
                // SerieId = contribuidorDto.SerieId,
                Funcao = contribuidorDto.Funcao
            };
        }
    }
}