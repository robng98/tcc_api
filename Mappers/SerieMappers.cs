using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using tcc1_api.Dtos.Manga;
using tcc1_api.Dtos.Serie;
using tcc1_api.Models;

namespace tcc1_api.Mappers
{
    public static class SerieMappers
    {
        public static SerieDto ToSerieDto(this Serie serie)
        {
            return new SerieDto
            {
                Id = serie.Id,
                EstadoPubAtual = serie.EstadoPubAtual,
                NomeInter = serie.NomeInter,
                CicloNum = serie.CicloNum,
                Generos = serie.Generos.Select(g => g.ToGeneroDto()).ToList(),
                NumEdicoes = serie.Edicoes.Select(e => e.ToEdicaoDto()).Count(),
                EditoraId = serie.EditoraId
            };
        }

        public static SerieMangaDto ToSerieMangaDto(this Serie serie)
        {
            return new SerieMangaDto
            {
                Id = serie.Id,
                EstadoPubAtual = serie.EstadoPubAtual,
                NomeInter = serie.NomeInter,
                CicloNum = serie.CicloNum,
                Generos = serie.Generos.Select(g => g.ToGeneroDto()).ToList(),
                NumEdicoes = serie.Edicoes.Select(e => e.ToEdicaoDto()).Count(),
                MangaStats = serie.Manga.ToMangaDto(),
                EditoraId = serie.EditoraId
            };
        }

        public static Serie ToSerieFromCreateDTO(this CreateSerieRequestDto serieDto, int editoraId)
        {
            return new Serie
            {
                EstadoPubAtual = serieDto.EstadoPubAtual,
                NomeInter = serieDto.NomeInter,
                CicloNum = serieDto.CicloNum,
                EditoraId = editoraId
            };
        }
        
        public static Serie ToSerieFromUpdateDTO(this UpdateSerieRequestDto serieDto, int editoraId)
        {
            return new Serie
            {
                EstadoPubAtual = serieDto.EstadoPubAtual,
                NomeInter = serieDto.NomeInter,
                CicloNum = serieDto.CicloNum,
                EditoraId = editoraId
            };
        }
    }
}