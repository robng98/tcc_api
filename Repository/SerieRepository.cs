using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using tcc1_api.Data;
using tcc1_api.Dtos.Serie;
using tcc1_api.Extensions;
using tcc1_api.Helpers;
using tcc1_api.Interfaces;
using tcc1_api.Models;

namespace tcc1_api.Repository
{
    public class SerieRepository : ISerieRepository
    {
        private readonly ApplicationDbContext _context;

        public SerieRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Serie> CreateSerieAsync(Serie serieModel)
        {
            await _context.Series.AddAsync(serieModel);
            await _context.SaveChangesAsync();
            return serieModel;
        }

        public async Task<Serie?> DeleteSerieAsync(int id)
        {
            var serieModel = await _context.Series.FirstOrDefaultAsync(e => e.Id == id);

            if (serieModel == null)
            {
                return null;
            }

            _context.Series.Remove(serieModel);
            await _context.SaveChangesAsync();

            return serieModel;
        }

        public async Task<Serie?> GetSerieByIdAsync(int id)
        {
            return await _context.Series
                .Include(s => s.Editora)
                .Include(s => s.Edicoes)
                .Include(s => s.Manga)
                .Include(s => s.Generos)
                .FirstOrDefaultAsync(e => e.Id == id);
        }

        public async Task<(List<Serie> Series, int TotalCount)> GetSeriesAsync(SerieQueryObject query)
        {
            var series = _context.Series
                .Include(s => s.Editora)
                .Include(s => s.Edicoes)
                .Include(s => s.Manga)
                .Include(s => s.Generos)
                .AsQueryable();
            
            // Apply filters if provided
            if (!string.IsNullOrWhiteSpace(query.NomeInter))
            {
                series = series.Where(s => s.NomeInter.ToLower().Contains(query.NomeInter.ToLower()));
            }
            
            if (!string.IsNullOrWhiteSpace(query.EstadoPubAtual))
            {
                series = series.Where(s => s.EstadoPubAtual.ToLower().Contains(query.EstadoPubAtual.ToLower()));
            }
            
            if (query.EditoraId.HasValue)
            {
                series = series.Where(s => s.EditoraId == query.EditoraId);
            }
            
            return await ApplySortingAndPaginationAsync(series, query);
        }

        public async Task<(List<Serie> Series, int TotalCount)> GetSeriesComicsAsync(SerieQueryObject query)
        {
            var comics = _context.Series
                .Include(s => s.Editora)
                .Include(s => s.Edicoes)
                .Include(s => s.Generos)
                .Where(s => s.Manga == null)
                .AsQueryable();
            
            // Apply filters if provided
            if (!string.IsNullOrWhiteSpace(query.NomeInter))
            {
                comics = comics.Where(s => s.NomeInter.ToLower().Contains(query.NomeInter.ToLower()));
            }
            
            if (!string.IsNullOrWhiteSpace(query.EstadoPubAtual))
            {
                comics = comics.Where(s => s.EstadoPubAtual.ToLower().Contains(query.EstadoPubAtual.ToLower()));
            }
            
            if (query.EditoraId.HasValue)
            {
                comics = comics.Where(s => s.EditoraId == query.EditoraId);
            }
            
            return await ApplySortingAndPaginationAsync(comics, query);
        }

        public async Task<(List<Serie> Series, int TotalCount)> GetSeriesMangasAsync(SerieQueryObject query)
        {
            var mangas = _context.Series
                .Include(s => s.Editora)
                .Include(s => s.Edicoes)
                .Include(s => s.Manga)
                .Include(s => s.Generos)
                .Where(s => s.Manga != null)
                .AsQueryable();
            
            // Apply filters if provided
            if (!string.IsNullOrWhiteSpace(query.NomeInter))
            {
                mangas = mangas.Where(s => s.NomeInter.ToLower().Contains(query.NomeInter.ToLower()));
            }
            
            if (!string.IsNullOrWhiteSpace(query.EstadoPubAtual))
            {
                mangas = mangas.Where(s => s.EstadoPubAtual.ToLower().Contains(query.EstadoPubAtual.ToLower()));
            }
            
            if (query.EditoraId.HasValue)
            {
                mangas = mangas.Where(s => s.EditoraId == query.EditoraId);
            }
            
            return await ApplySortingAndPaginationAsync(mangas, query);
        }

        public async Task<Serie?> UpdateSerieAsync(int id, Serie serieModel)
        {
            var existingSerie = await _context.Series.FirstOrDefaultAsync(e => e.Id == id);

            if (existingSerie == null)
            {
                return null;
            }

            existingSerie.NomeInter = serieModel.NomeInter;
            existingSerie.CicloNum = serieModel.CicloNum;
            existingSerie.EstadoPubAtual = serieModel.EstadoPubAtual;

            await _context.SaveChangesAsync();

            return existingSerie;
        }

        private async Task<(List<Serie> Series, int TotalCount)> ApplySortingAndPaginationAsync(
            IQueryable<Serie> query, SerieQueryObject queryObject)
        {
            bool isSortingByNumEdicoes = queryObject.SortBy?.Equals("NumEdicoes", StringComparison.OrdinalIgnoreCase) == true;
            
            var totalCount = await query.CountAsync();
            
            if (isSortingByNumEdicoes)
            {
                var allItems = await query.ToListAsync();
                
                var sortedItems = queryObject.IsDescending
                    ? allItems.OrderByDescending(s => s.Edicoes.Count).ToList()
                    : allItems.OrderBy(s => s.Edicoes.Count).ToList();
                
                var skipNumber = queryObject.PageSize * (queryObject.PageNumber - 1);
                var pagedItems = sortedItems
                    .Skip(skipNumber)
                    .Take(queryObject.PageSize)
                    .ToList();
                
                return (pagedItems, totalCount);
            }
            else
            {
                query = query.ApplySort(queryObject.SortBy, queryObject.IsDescending);
                
                var skipNumber = queryObject.PageSize * (queryObject.PageNumber - 1);
                var pagedItems = await query
                    .Skip(skipNumber)
                    .Take(queryObject.PageSize)
                    .ToListAsync();
                
                return (pagedItems, totalCount);
            }
        }
    }
}