using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using tcc1_api.Helpers;
using tcc1_api.Models;

namespace tcc1_api.Interfaces
{
    public interface IGeneroRepository
    {
        Task<List<Genero>> GetGenerosAsync(GeneroQueryObject query);
        Task<Genero?> GetGeneroByIdAsync(int id);
        Task<Genero> CreateGeneroAsync(Genero generoModel);
        Task<Genero?> UpdateGeneroAsync(int id, Genero generoModel);
        Task<Genero?> DeleteGeneroAsync(int id);
    }
}