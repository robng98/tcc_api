using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using tcc1_api.Data;
using tcc1_api.Dtos.Contribui;
using tcc1_api.Extensions;
using tcc1_api.Helpers;
using tcc1_api.Interfaces;
using tcc1_api.Models;

namespace tcc1_api.Repository
{
    public class ContribuiRepository : IContribuiRepository
    {
        private readonly ApplicationDbContext _context;
        public ContribuiRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Contribui> CreateContribuiAsync(Contribui contribuiModel)
        {
            await _context.Contribui.AddAsync(contribuiModel);
            await _context.SaveChangesAsync();
            return contribuiModel;
        }

        public async Task<Contribui?> DeleteContribuiAsync(int contribuidorId, int edicaoId)
        {
            var contribuiModel = await _context.Contribui.FirstOrDefaultAsync(e =>
                e.ContribuidorId == contribuidorId && e.EdicaoId == edicaoId);

            if (contribuiModel == null)
            {
                return null;
            }

            _context.Contribui.Remove(contribuiModel);
            await _context.SaveChangesAsync();

            return contribuiModel;
        }

        public async Task<(List<ContribuiNormalDto> Contribuicoes, int TotalCount)> GetContribuidoresEdicaoAsync(ContribuiQueryObject query)
        {
            var contribuicoes = _context.Contribui
                .Include(c => c.Contribuidor) // Include related Contribuidor for more context
                .AsQueryable();

            // Apply filters if provided
            if (query.EdicaoId.HasValue)
            {
                contribuicoes = contribuicoes.Where(e => e.EdicaoId == query.EdicaoId);
            }

            // Apply filters if provided
            if (query.ContribuidorId.HasValue)
            {
                contribuicoes = contribuicoes.Where(e => e.ContribuidorId == query.ContribuidorId);
            }
            
            // Apply sorting using the extension method
            contribuicoes = contribuicoes.ApplySort(query.SortBy, query.IsDescending);
            
            // Get total count for pagination
            var totalCount = await contribuicoes.CountAsync();
            
            // Apply pagination
            var skipNumber = query.PageSize * (query.PageNumber - 1);
            
            var paginatedResults = await contribuicoes
                .Skip(skipNumber)
                .Take(query.PageSize)
                .Select(contribui => new ContribuiNormalDto
                {
                    ContribuidorId = contribui.ContribuidorId,
                    EdicaoId = contribui.EdicaoId,
                    ContribuidorNome = contribui.Contribuidor.Nome,
                    Funcao = contribui.Funcao
                })
                .ToListAsync();
                
            return (paginatedResults, totalCount);
        }
    }
}