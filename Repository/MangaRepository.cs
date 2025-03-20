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
    public class MangaRepository : IMangaRepository
    {
        private readonly ApplicationDbContext _context;
        public MangaRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<Manga> CreateMangaAsync(Manga mangaModel)
        {
            await _context.Mangas.AddAsync(mangaModel);
            await _context.SaveChangesAsync();
            return mangaModel;
        }

        public async Task<Manga?> DeleteMangaAsync(int id)
        {
            var mangaModel = await _context.Mangas.FirstOrDefaultAsync(e => e.Id == id);

            if (mangaModel == null)
            {
                return null;
            }

            _context.Mangas.Remove(mangaModel);
            await _context.SaveChangesAsync();

            return mangaModel;
        }

        public async Task<Manga?> GetMangaByIdAsync(int id)
        {
            return await _context.Mangas.FirstOrDefaultAsync(e => e.Id == id);
        }

        public async Task<List<Manga>> GetMangasAsync(MangaQueryObject query)
        {
            var manga = _context.Mangas.AsQueryable();

            if (!string.IsNullOrWhiteSpace(query.NomeJap))
            {
                manga = manga.Where(e => e.NomeJap.Contains(query.NomeJap));
            }
            if (!string.IsNullOrWhiteSpace(query.Demografia))
            {
                manga = manga.Where(e => e.Demografia.ToLower().Contains(query.Demografia.ToLower()));
            }
            if (query.SerieId != -1)
            {
                manga = manga.Where(e => e.SerieId == query.SerieId);
            }

            var skipNumber = query.PageSize * (query.PageNumber - 1);

            return await manga.Skip(skipNumber).Take(query.PageSize).ToListAsync();
        }

        public async Task<Manga?> UpdateMangaAsync(int id, Manga mangaModel)
        {
            var existingManga = await _context.Mangas.FirstOrDefaultAsync(e => e.Id == id);

            if (existingManga == null)
            {
                return null;
            }

            existingManga.NomeJap = mangaModel.NomeJap;
            existingManga.Demografia = mangaModel.Demografia;

            await _context.SaveChangesAsync();

            return existingManga;
        }
    }
}