using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using tcc1_api.Dtos.Exemplar;
using tcc1_api.Models;

namespace tcc1_api.Mappers
{
    public static class ExemplarMappers
    {
        public static ExemplarDto ToExemplarDto(this Exemplar exemplar)
        {
            return new ExemplarDto
            {
                Id = exemplar.Id,
                EstadoConservacao = exemplar.EstadoConservacao,
                DataAquisicao = exemplar.DataAquisicao,
                EdicaoId = exemplar.EdicaoId,
                ColecaoId = exemplar.ColecaoId

            };
        }

        public static Exemplar ToExemplarFromCreateDTO(this CreateExemplarRequestDto exemplarDto, int edicaoId, int colecaoId)
        {
            return new Exemplar
            {
                EstadoConservacao = exemplarDto.EstadoConservacao,
                DataAquisicao = exemplarDto.DataAquisicao,
                ColecaoId = colecaoId,
                EdicaoId = edicaoId
            };
        }
        
        public static Exemplar ToExemplarFromUpdateDTO(this UpdateExemplarRequestDto exemplarDto)
        // public static Exemplar ToExemplarFromUpdateDTO(this UpdateExemplarRequestDto exemplarDto, int edicaoId, int colecaoId)
        {
            return new Exemplar
            {
                EstadoConservacao = exemplarDto.EstadoConservacao,
                DataAquisicao = exemplarDto.DataAquisicao,
                // ColecaoId = colecaoId,
                // EdicaoId = edicaoId
            };
        }
    }
}