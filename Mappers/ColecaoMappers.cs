using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using tcc1_api.Dtos.Colecao;
using tcc1_api.Models;

namespace tcc1_api.Mappers
{
    public static class ColecaoMappers
    {
        public static ColecaoDto ToColecaoDto(this Colecao colecao)
        {
            return new ColecaoDto
            {
                Id = colecao.Id,
                NomeColecao = colecao.NomeColecao,
                Exemplares = colecao.Exemplares.Select(e => e.ToExemplarDto()).ToList()
            };
        }

        // public static Colecao ToColecaoFromCreateDTO(this CreateColecaoRequestDto colecaoDto, int serieId)
        // {
        //     return new Colecao
        //     {
        //         FotoCapa = colecaoDto.FotoCapa,
        //         Numero = colecaoDto.Numero,
        //         UnMonetaria = colecaoDto.UnMonetaria,
        //         Preco = colecaoDto.Preco,
        //         DataLancamento = colecaoDto.DataLancamento,
        //         SerieId = serieId
        //     };
        // }
        
        // public static Colecao ToColecaoFromUpdateDTO(this UpdateColecaoRequestDto colecaoDto, int serieId)
        // {
        //     return new Colecao
        //     {
        //         FotoCapa = colecaoDto.FotoCapa,
        //         Numero = colecaoDto.Numero,
        //         UnMonetaria = colecaoDto.UnMonetaria,
        //         Preco = colecaoDto.Preco,
        //         DataLancamento = colecaoDto.DataLancamento,
        //         SerieId = serieId
        //     };
        // }
    }
}