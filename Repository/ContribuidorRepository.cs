using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using tcc1_api.Data;
using tcc1_api.Dtos.Contribuidor;
using tcc1_api.Extensions;
using tcc1_api.Helpers;
using tcc1_api.Interfaces;
using tcc1_api.Models;

namespace tcc1_api.Repository
{
    public class ContribuidorRepository : IContribuidorRepository
    {
        private readonly ApplicationDbContext _context;

        public ContribuidorRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Contribuidor> CreateContribuidorAsync(Contribuidor contribuidorModel)
        {
            await _context.Contribuidores.AddAsync(contribuidorModel);
            await _context.SaveChangesAsync();
            return contribuidorModel;
        }

        public async Task<Contribuidor?> DeleteContribuidorAsync(int id)
        {
            var contribuidorModel = await _context.Contribuidores.FirstOrDefaultAsync(e => e.Id == id);

            if (contribuidorModel == null)
            {
                return null;
            }

            _context.Contribuidores.Remove(contribuidorModel);
            await _context.SaveChangesAsync();

            return contribuidorModel;
        }

        public async Task<Contribuidor?> GetContribuidorByIdAsync(int id)
        {
            return await _context.Contribuidores.FirstOrDefaultAsync(e => e.Id == id);
        }

        public async Task<(List<Contribuidor> Contribuidores, int TotalCount)> GetContribuidoresAsync(ContribuidorQueryObject query)
        {
            var contribuidores = _context.Contribuidores.AsQueryable();

            // Apply filters if provided
            if (!string.IsNullOrWhiteSpace(query.Nome))
            {
                contribuidores = contribuidores.Where(e => e.Nome.ToLower().Contains(query.Nome.ToLower()));
            }
            
            // Apply sorting using the extension method
            contribuidores = contribuidores.ApplySort(query.SortBy, query.IsDescending);
            
            // Get total count for pagination
            var totalCount = await contribuidores.CountAsync();
            
            // Apply pagination
            var skipNumber = query.PageSize * (query.PageNumber - 1);
            var pagedContribuidores = await contribuidores
                .Skip(skipNumber)
                .Take(query.PageSize)
                .ToListAsync();
            
            return (pagedContribuidores, totalCount);
        }

        public async Task<Contribuidor?> UpdateContribuidorAsync(int id, UpdateContribuidorRequestDto updateContribuidorDto)
        {
            var existingContribuidor = await _context.Contribuidores.FirstOrDefaultAsync(e => e.Id == id);

            if (existingContribuidor == null)
            {
                return null;
            }

            existingContribuidor.Nome = updateContribuidorDto.Nome;
            existingContribuidor.Genero = updateContribuidorDto.Genero;
            existingContribuidor.DataNasc = updateContribuidorDto.DataNasc;

            await _context.SaveChangesAsync();

            return existingContribuidor;
        }
    }
}