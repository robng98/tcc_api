using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using tcc1_api.Data;
using tcc1_api.Helpers;
using tcc1_api.Interfaces;
using tcc1_api.Models;

namespace tcc1_api.Repository
{
    public class TankobonRepository : ITankobonRepository
    {
        private readonly ApplicationDbContext _context;
        public TankobonRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<Tankobon> CreateTankobonAsync(Tankobon tankobonModel)
        {
            await _context.Tankobons.AddAsync(tankobonModel);
            await _context.SaveChangesAsync();
            return tankobonModel;
        }

        public async Task<Tankobon?> DeleteTankobonAsync(int id)
        {
            var tankobonModel = await _context.Tankobons.FirstOrDefaultAsync(e => e.Id == id);

            if (tankobonModel == null)
            {
                return null;
            }

            _context.Tankobons.Remove(tankobonModel);
            await _context.SaveChangesAsync();

            return tankobonModel;
        }

        public async Task<Tankobon?> GetTankobonByIdAsync(int id)
        {
            return await _context.Tankobons.Include(e => e.Edicao).FirstOrDefaultAsync(e => e.Id == id);
        }

        public async Task<Tankobon?> GetTankobonByEdicaoIdAsync(int edicaoId)
        {
            return await _context.Tankobons.Include(e => e.Edicao).FirstOrDefaultAsync(e => e.EdicaoId == edicaoId);
        }

        public async Task<List<Tankobon>> GetTankobonsAsync(TankobonQueryObject query)
        {
            var tankobon = _context.Tankobons.Include(e => e.Edicao).AsQueryable();

            var skipNumber = query.PageSize * (query.PageNumber - 1);

            return await tankobon.Skip(skipNumber).Take(query.PageSize).ToListAsync();
        }

        public async Task<Tankobon?> UpdateTankobonAsync(int id, Tankobon tankobonModel)
        {
            var existingTankobon = await _context.Tankobons.FirstOrDefaultAsync(e => e.Id == id);

            if (existingTankobon == null)
            {
                return null;
            }

            existingTankobon.NumeroCapitulos = tankobonModel.NumeroCapitulos;

            await _context.SaveChangesAsync();

            return existingTankobon;
        }
    }
}