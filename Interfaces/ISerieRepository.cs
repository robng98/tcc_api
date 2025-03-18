using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using tcc1_api.Dtos.Serie;
using tcc1_api.Helpers;
using tcc1_api.Models;

namespace tcc1_api.Interfaces
{
    public interface ISerieRepository
    {
        Task<(List<Serie> Series, int TotalCount)> GetSeriesAsync(SerieQueryObject query);
        Task<(List<Serie> Series, int TotalCount)> GetSeriesComicsAsync(SerieQueryObject query);
        Task<(List<Serie> Series, int TotalCount)> GetSeriesMangasAsync(SerieQueryObject query);
        Task<Serie?> GetSerieByIdAsync(int id);
        Task<Serie> CreateSerieAsync(Serie serieModel);
        Task<Serie?> UpdateSerieAsync(int id, Serie serieModel);
        Task<Serie?> DeleteSerieAsync(int id);
    }
}