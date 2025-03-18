using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using tcc1_api.Helpers;
using tcc1_api.Models;

namespace tcc1_api.Interfaces
{
    public interface IMangaRepository
    {
        Task<List<Manga>> GetMangasAsync(MangaQueryObject query);
        Task<Manga?> GetMangaByIdAsync(int id);
        Task<Manga> CreateMangaAsync(Manga mangaModel);
        Task<Manga?> UpdateMangaAsync(int id, Manga mangaModel);
        Task<Manga?> DeleteMangaAsync(int id);
    }
}