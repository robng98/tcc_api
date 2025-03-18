using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using tcc1_api.Helpers;
using tcc1_api.Models;

namespace tcc1_api.Interfaces
{
    public interface ITankobonRepository
    {
        Task<List<Tankobon>> GetTankobonsAsync(TankobonQueryObject query);
        Task<Tankobon?> GetTankobonByIdAsync(int id);
        Task<Tankobon?> GetTankobonByEdicaoIdAsync(int edicaoId);
        Task<Tankobon> CreateTankobonAsync(Tankobon tankobonModel);
        Task<Tankobon?> UpdateTankobonAsync(int id, Tankobon tankobonModel);
        Task<Tankobon?> DeleteTankobonAsync(int id);
    }
}