using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using tcc1_api.Helpers;
using tcc1_api.Models;

namespace tcc1_api.Interfaces
{
    public interface IEdicaoRepository
    {
        Task<(List<Edicao> Edicoes, int TotalCount)> GetEdicoesAsync(EdicaoQueryObject query);
        Task<(List<Edicao> Edicoes, int TotalCount)> GetEdicoesBySerieIdAsync(int serieId, EdicaoQueryObject query);
        // Task<List<Edicao>> GetEdicoesAsync(EdicaoQueryObject query);
        // Task<List<Edicao>> GetEdicoesBySerieIdAsync(int serieId, EdicaoQueryObject query);
        Task<Edicao?> GetEdicaoByIdAsync(int id);
        Task<Edicao> CreateEdicaoAsync(Edicao edicaoModel);
        Task<Edicao?> UpdateEdicaoAsync(int id, Edicao edicaoModel);
        Task<Edicao?> DeleteEdicaoAsync(int id);
    }
}