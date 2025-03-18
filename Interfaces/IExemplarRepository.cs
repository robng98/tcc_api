using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using tcc1_api.Dtos.Exemplar;
using tcc1_api.Helpers;
using tcc1_api.Models;

namespace tcc1_api.Interfaces
{
    public interface IExemplarRepository
    {
        Task<(List<Exemplar> Exemplares, int TotalCount)> GetExemplaresAsync(ExemplarQueryObject query, string userId);
        Task<Exemplar?> GetExemplarByIdAsync(int id, string userId);
        Task<Exemplar> CreateExemplarAsync(Exemplar exemplarModel);
        Task<Exemplar?> UpdateExemplarAsync(int id, Exemplar exemplarModel, string userId);
        Task<Exemplar?> DeleteExemplarAsync(int id, string userId);
    }
}