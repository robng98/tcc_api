using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using tcc1_api.Helpers;
using tcc1_api.Models;

namespace tcc1_api.Interfaces
{
    public interface IColecaoRepository
    {
        Task<(List<Colecao> Colecoes, int TotalCount)> GetUserColecoes(AppUser user, ColecaoQueryObject query);
        Task<List<Colecao>> GetUserColecoes(AppUser user);
        Task<Colecao?> GetColecaoWithDetailsAsync(int colecaoId);
        Task<Colecao> CreateColecaoAsync(Colecao colecao);
        Task<Colecao> DeleteColecaoAsync(AppUser appUser, int colecaoId);
    }
}