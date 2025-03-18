using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using tcc1_api.Dtos.Genero;
using tcc1_api.Models;

namespace tcc1_api.Mappers
{
    public static class GeneroMappers
    {
        public static GeneroDto ToGeneroDto(this Genero genero)
        {
            return new GeneroDto
            {
                Id = genero.Id,
                Tipo = genero.Tipo,
                SerieId = genero.SerieId
            };
        }

        public static Genero ToGeneroFromCreateDTO(this CreateGeneroRequestDto generoDto, int serieId)
        {
            return new Genero
            {
                Tipo = generoDto.Tipo,
                SerieId = serieId
            };
        }
        
        public static Genero ToGeneroFromUpdateDTO(this UpdateGeneroRequestDto generoDto, int serieId)
        {
            return new Genero
            {
                Tipo = generoDto.Tipo,
                SerieId = serieId
            };
        }
    }
}