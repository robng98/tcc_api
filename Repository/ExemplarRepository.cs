using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using tcc1_api.Data;
using tcc1_api.Dtos.Exemplar;
using tcc1_api.Extensions;
using tcc1_api.Helpers;
using tcc1_api.Interfaces;
using tcc1_api.Models;

namespace tcc1_api.Repository
{
    public class ExemplarRepository : IExemplarRepository
    {
        private readonly ApplicationDbContext _context;

        public ExemplarRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Exemplar> CreateExemplarAsync(Exemplar exemplarModel)
        {
            // Convert the acquisition date to UTC
            if (exemplarModel.DataAquisicao.Kind != DateTimeKind.Utc)
            {
                exemplarModel.DataAquisicao = DateTime.SpecifyKind(exemplarModel.DataAquisicao, DateTimeKind.Utc);
            }

            await _context.Exemplares.AddAsync(exemplarModel);
            await _context.SaveChangesAsync();
            return exemplarModel;
        }

        public async Task<Exemplar?> DeleteExemplarAsync(int id, string userId)
        {
            var exemplarModel = await _context.Exemplares
                .Include(e => e.Colecao)
                .FirstOrDefaultAsync(e => e.Id == id && e.Colecao.AppUserId == userId);

            if (exemplarModel == null)
            {
                return null;
            }

            _context.Exemplares.Remove(exemplarModel);
            await _context.SaveChangesAsync();

            return exemplarModel;
        }

        public async Task<Exemplar?> GetExemplarByIdAsync(int id, string userId)
        {
            return await _context.Exemplares
                .Include(e => e.Edicao)
                    .ThenInclude(ed => ed.Serie)
                .Include(e => e.Colecao)
                .FirstOrDefaultAsync(e => e.Id == id && e.Colecao.AppUserId == userId);
        }

        public async Task<(List<Exemplar> Exemplares, int TotalCount)> GetExemplaresAsync(ExemplarQueryObject query, string userId)
        {
            var exemplares = _context.Exemplares
                .Include(e => e.Edicao)
                    .ThenInclude(ed => ed.Serie)
                .Include(e => e.Colecao)
                .Where(e => e.Colecao.AppUserId == userId)
                .AsQueryable();

            // Apply filters if provided
            if (!string.IsNullOrWhiteSpace(query.EstadoConservacao))
            {
                exemplares = exemplares.Where(e => e.EstadoConservacao.ToLower().Contains(query.EstadoConservacao.ToLower()));
            }

            if (query.EdicaoId.HasValue)
            {
                exemplares = exemplares.Where(e => e.EdicaoId == query.EdicaoId);
            }

            if (query.ColecaoId.HasValue)
            {
                exemplares = exemplares.Where(e => e.ColecaoId == query.ColecaoId);
            }

            if(query.SerieNome != null)
            {
                exemplares = exemplares.Where(e => e.Edicao.Serie.NomeInter.ToLower().Contains(query.SerieNome.ToLower()));
            }
            
            // Apply sorting using the extension method
            exemplares = exemplares.ApplySort(query.SortBy, query.IsDescending);
            
            // Get total count for pagination
            var totalCount = await exemplares.CountAsync();
            
            // Apply pagination
            var skipNumber = query.PageSize * (query.PageNumber - 1);
            var pagedExemplares = await exemplares
                .Skip(skipNumber)
                .Take(query.PageSize)
                .ToListAsync();
            
            return (pagedExemplares, totalCount);
        }

        public async Task<Exemplar?> UpdateExemplarAsync(int exemplarId, Exemplar exemplarModel, string userId)
        {
            var existingExemplar = await _context.Exemplares
                .Include(e => e.Colecao)
                .FirstOrDefaultAsync(e => e.Id == exemplarId && e.Colecao.AppUserId == userId);

            if (existingExemplar == null)
            {
                return null;
            }

            existingExemplar.EstadoConservacao = exemplarModel.EstadoConservacao;
            existingExemplar.DataAquisicao = exemplarModel.DataAquisicao;

            await _context.SaveChangesAsync();

            return existingExemplar;
        }
    }
}