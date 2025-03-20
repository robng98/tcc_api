using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using tcc1_api.Data;
using tcc1_api.Extensions;
using tcc1_api.Helpers;
using tcc1_api.Interfaces;
using tcc1_api.Models;

namespace tcc1_api.Repository
{
    public class ColecaoRepository : IColecaoRepository
    {
        private readonly ApplicationDbContext _context;
        public ColecaoRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        // Original method maintained for backward compatibility
        public async Task<List<Colecao>> GetUserColecoes(AppUser user)
        {
            return await _context.Colecoes.Where(u => u.AppUserId == user.Id)
            .Select(colecao => new Colecao
            {
                Id = colecao.Id,
                NomeColecao = colecao.NomeColecao,
                Exemplares = colecao.Exemplares
            }).ToListAsync();
        }

        // New paginated method
        public async Task<(List<Colecao> Colecoes, int TotalCount)> GetUserColecoes(AppUser user, ColecaoQueryObject query)
        {
            var colecoes = _context.Colecoes
                .Where(c => c.AppUserId == user.Id)
                .Include(c => c.Exemplares) // Added this line to include exemplares
                    .ThenInclude(e => e.Edicao) // Include related Edicao for more context
                .AsQueryable();
                
            // Apply filters if provided
            if (!string.IsNullOrWhiteSpace(query.NomeColecao))
            {
                colecoes = colecoes.Where(c => c.NomeColecao.ToLower().Contains(query.NomeColecao.ToLower()));
            }
            
            // Apply sorting using the extension method
            colecoes = colecoes.ApplySort(query.SortBy, query.IsDescending);
            
            // Get total count for pagination
            var totalCount = await colecoes.CountAsync();
            
            // Apply pagination
            var skipNumber = query.PageSize * (query.PageNumber - 1);
            var pagedColecoes = await colecoes
                .Skip(skipNumber)
                .Take(query.PageSize)
                .ToListAsync();
                
            return (pagedColecoes, totalCount);
        }

        public async Task<Colecao> CreateColecaoAsync(Colecao colecao)
        {
            await _context.Colecoes.AddAsync(colecao);
            await _context.SaveChangesAsync();
            return colecao;
        }

        public async Task<Colecao> DeleteColecaoAsync(AppUser appUser, int colecaoId)
        {
            var colecaoModel = await _context.Colecoes.FirstOrDefaultAsync(c => c.AppUserId == appUser.Id && c.Id == colecaoId);

            if (colecaoModel == null)
            {
                return null;
            }

            _context.Colecoes.Remove(colecaoModel);
            await _context.SaveChangesAsync();
            return colecaoModel;
        }

        public async Task<Colecao?> GetColecaoWithDetailsAsync(int colecaoId)
        {
            return await _context.Colecoes
                .Include(c => c.Exemplares)
                    .ThenInclude(e => e.Edicao)
                        .ThenInclude(ed => ed.Serie)
                            .ThenInclude(s => s.Manga) // Include Manga with Series
                .Include(c => c.Exemplares)
                    .ThenInclude(e => e.Edicao)
                        .ThenInclude(ed => ed.Contribuicoes)
                            .ThenInclude(c => c.Contribuidor)
                .Include(c => c.Exemplares)
                    .ThenInclude(e => e.Edicao)
                        .ThenInclude(ed => ed.Serie)
                            .ThenInclude(s => s.Generos)
                .Include(c => c.Exemplares)
                    .ThenInclude(e => e.Edicao)
                        .ThenInclude(ed => ed.Serie)
                            .ThenInclude(s => s.Editora)
                .FirstOrDefaultAsync(c => c.Id == colecaoId);
        }
    }
}