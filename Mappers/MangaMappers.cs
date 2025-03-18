using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using tcc1_api.Dtos.Manga;
using tcc1_api.Models;

namespace tcc1_api.Mappers
{
    public static class MangaMappers
    {
        public static MangaDto ToMangaDto(this Manga manga)
        {
            return new MangaDto
            {
                Id = manga.Id,
                NomeJap = manga.NomeJap,
                Demografia = manga.Demografia,
                SerieId = manga.SerieId,
                // Serie = manga.Serie?.ToSerieDto()
            };
        }

        public static Manga ToMangaFromCreateDTO(this CreateMangaRequestDto mangaDto, int serieId)
        {
            return new Manga
            {
                NomeJap = mangaDto.NomeJap,
                Demografia = mangaDto.Demografia,
                SerieId = serieId
            };
        }
        
        public static Manga ToMangaFromUpdateDTO(this UpdateMangaRequestDto mangaDto, int serieId)
        {
            return new Manga
            {
                NomeJap = mangaDto.NomeJap,
                Demografia = mangaDto.Demografia,
                SerieId = serieId
            };
        }
    }
}