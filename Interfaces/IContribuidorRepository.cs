using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using tcc1_api.Dtos.Contribuidor;
using tcc1_api.Helpers;
using tcc1_api.Models;

namespace tcc1_api.Interfaces
{
    public interface IContribuidorRepository
    {
        Task<(List<Contribuidor> Contribuidores, int TotalCount)> GetContribuidoresAsync(ContribuidorQueryObject query);
        Task<Contribuidor?> GetContribuidorByIdAsync(int id);
        Task<Contribuidor> CreateContribuidorAsync(Contribuidor contribuidorModel);
        Task<Contribuidor?> UpdateContribuidorAsync(int id, UpdateContribuidorRequestDto updateContribuidorDto);
        Task<Contribuidor?> DeleteContribuidorAsync(int id);
    }
}