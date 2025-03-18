using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using tcc1_api.Dtos.Edicao;
using tcc1_api.Models;

namespace tcc1_api.Mappers
{
    public static class EdicaoMappers
    {
        public static EdicaoDto ToEdicaoDto(this Edicao edicao)
        {
            return new EdicaoDto
            {
                Id = edicao.Id,
                FotoCapa = edicao.FotoCapa,
                Numero = edicao.Numero,
                UnMonetaria = edicao.UnMonetaria,
                Preco = edicao.Preco,
                DataLancamento = edicao.DataLancamento,
                SerieId = edicao.SerieId
            };
        }

        public static EdicaoDto ToEdicaoWithSerieDto(this Edicao edicao, string serieNome)
        {
            return new EdicaoDto
            {
                Id = edicao.Id,
                FotoCapa = edicao.FotoCapa,
                Numero = edicao.Numero,
                UnMonetaria = edicao.UnMonetaria,
                Preco = edicao.Preco,
                DataLancamento = edicao.DataLancamento,
                SerieId = edicao.SerieId,
                SerieNome = serieNome
            };
        }

        public static Edicao ToEdicaoFromCreateDTO(this CreateEdicaoRequestDto edicaoDto, int serieId)
        {
            return new Edicao
            {
                FotoCapa = edicaoDto.FotoCapa,
                Numero = edicaoDto.Numero,
                UnMonetaria = edicaoDto.UnMonetaria,
                Preco = edicaoDto.Preco,
                DataLancamento = edicaoDto.DataLancamento,
                SerieId = serieId
            };
        }
        
        public static Edicao ToEdicaoFromUpdateDTO(this UpdateEdicaoRequestDto edicaoDto, int serieId)
        {
            return new Edicao
            {
                FotoCapa = edicaoDto.FotoCapa,
                Numero = edicaoDto.Numero,
                UnMonetaria = edicaoDto.UnMonetaria,
                Preco = edicaoDto.Preco,
                DataLancamento = edicaoDto.DataLancamento,
                SerieId = serieId
            };
        }
    }
}