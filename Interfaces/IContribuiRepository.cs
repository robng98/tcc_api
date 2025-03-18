using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using tcc1_api.Dtos.Contribui;
using tcc1_api.Helpers;
using tcc1_api.Models;

namespace tcc1_api.Interfaces
{
    public interface IContribuiRepository
    {
        Task<(List<ContribuiNormalDto> Contribuicoes, int TotalCount)> GetContribuidoresEdicaoAsync(ContribuiQueryObject query);
        Task<Contribui> CreateContribuiAsync(Contribui contribuiModel);
        Task<Contribui?> DeleteContribuiAsync(int contribuidorId, int edicaoId);
    }
}