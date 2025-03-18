using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using tcc1_api.Dtos.Contribuidor;
using tcc1_api.Dtos.Serie;
using tcc1_api.Models;

namespace tcc1_api.Mappers
{
    public static class ContribuidorMappers
    {
        public static ContribuidorDto ToContribuidorDto(this Contribuidor contribuidor)
        {
            return new ContribuidorDto
            {
                Id = contribuidor.Id,
                Genero = contribuidor.Genero,
                Nome = contribuidor.Nome,
                DataNasc = contribuidor.DataNasc,
                Foto = contribuidor.Foto
                // Series = contribuidor.Contribuicoes.Select(s => new SerieDto{
                //     Id = s.SerieId,
                //     EstadoPubAtual = s.Serie.EstadoPubAtual,
                //     NomeInter = s.Serie.NomeInter,
                //     CicloNum = s.Serie.CicloNum,
                //     EditoraId = s.Serie.EditoraId
                // }).ToList()
            };
        }

        public static Contribuidor ToContribuidorFromCreateContribuidorDTO(this CreateContribuidorRequestDto contribuidorDto)
        {
            return new Contribuidor
            {
                Genero = contribuidorDto.Genero,
                Nome = contribuidorDto.Nome,
                DataNasc = contribuidorDto.DataNasc,
            };
        }

        public static Contribuidor ToContribuidorFromUpdateContribuidorDTO(this UpdateContribuidorRequestDto contribuidorDto)
        {
            return new Contribuidor
            {
                Genero = contribuidorDto.Genero,
                Nome = contribuidorDto.Nome,
                DataNasc = contribuidorDto.DataNasc,
            };
        }
    }
}