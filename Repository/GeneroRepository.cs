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
    public class GeneroRepository : IGeneroRepository
    {
        private readonly ApplicationDbContext _context;
        public GeneroRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        
        public async Task<Genero> CreateGeneroAsync(Genero generoModel)
        {
            await _context.Generos.AddAsync(generoModel);
            await _context.SaveChangesAsync();
            return generoModel;
        }

        public async Task<Genero?> DeleteGeneroAsync(int id)
        {
            var generoModel = await _context.Generos.FirstOrDefaultAsync(e => e.Id == id);

            if (generoModel == null)
            {
                return null;
            }

            _context.Generos.Remove(generoModel);
            await _context.SaveChangesAsync();

            return generoModel;
        }

        public async Task<Genero?> GetGeneroByIdAsync(int id)
        {
            return await _context.Generos.FirstOrDefaultAsync(e => e.Id == id);
        }

        public async Task<List<Genero>> GetGenerosAsync(GeneroQueryObject query)
        {
            var genero = _context.Generos.AsQueryable();

            var skipNumber = query.PageSize * (query.PageNumber - 1);

            return await genero.Skip(skipNumber).Take(query.PageSize).ToListAsync();
        }

        public async Task<Genero?> UpdateGeneroAsync(int id, Genero generoModel)
        {
            var existingGenero = await _context.Generos.FirstOrDefaultAsync(e => e.Id == id);

            if (existingGenero == null)
            {
                return null;
            }

            existingGenero.Tipo = generoModel.Tipo;

            await _context.SaveChangesAsync();

            return existingGenero;
        }
    }
}