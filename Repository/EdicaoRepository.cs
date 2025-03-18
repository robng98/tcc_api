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
    public class EdicaoRepository : IEdicaoRepository
    {
        private readonly ApplicationDbContext _context;

        public EdicaoRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<Edicao> CreateEdicaoAsync(Edicao edicaoModel)
        {
            await _context.Edicoes.AddAsync(edicaoModel);
            await _context.SaveChangesAsync();
            return edicaoModel;
        }

        public async Task<Edicao?> DeleteEdicaoAsync(int id)
        {
            var edicaoModel = await _context.Edicoes.FirstOrDefaultAsync(e => e.Id == id);

            if (edicaoModel == null)
            {
                return null;
            }

            _context.Edicoes.Remove(edicaoModel);
            await _context.SaveChangesAsync();

            return edicaoModel;
        }

        public async Task<Edicao?> GetEdicaoByIdAsync(int id)
        {
            return await _context.Edicoes.Include(e => e.Serie).FirstOrDefaultAsync(e => e.Id == id);
        }

        // public async Task<List<Edicao>> GetEdicoesAsync(EdicaoQueryObject query)
        // {
        //     var edicoes = _context.Edicoes.Include(c => c.Serie).OrderByDescending(e => e.Id).AsQueryable();

        //     if (!string.IsNullOrWhiteSpace(query.Numero))
        //     {
        //         edicoes = edicoes.Where(e => e.Numero.Contains(query.Numero));
        //     }

        //     var skipNumber = query.PageSize * (query.PageNumber - 1);

        //     return await edicoes.Skip(skipNumber).Take(query.PageSize).ToListAsync();
        // }

        // public async Task<List<Edicao>> GetEdicoesBySerieIdAsync(int serieId, EdicaoQueryObject query)
        // {
        //     var edicoes = _context
        //     .Edicoes
        //     .Include(e => e.Serie)
        //     .Where(e => e.SerieId == serieId)
        //     .OrderByDescending(e => e.Id).AsQueryable();

        //     if (!string.IsNullOrWhiteSpace(query.Numero))
        //     {
        //         edicoes = edicoes.Where(e => e.Numero.Contains(query.Numero));
        //     }

        //     var skipNumber = query.PageSize * (query.PageNumber - 1);

        //     return await edicoes.Skip(skipNumber).Take(query.PageSize).ToListAsync();
        // }

        public async Task<(List<Edicao> Edicoes, int TotalCount)> GetEdicoesAsync(EdicaoQueryObject query)
        {
            // var edicoes = _context.Edicoes.Include(c => c.Serie).OrderBy(e => e.Id).AsQueryable();
            var edicoes = _context.Edicoes.Include(c => c.Serie).AsQueryable();


            if (!string.IsNullOrWhiteSpace(query.Numero))
            {
                edicoes = edicoes.Where(e => e.Numero.Contains(query.Numero));
            }

            edicoes = edicoes.ApplySort(query.SortBy, query.IsDescending);

            var totalCount = await edicoes.CountAsync();
            var skipNumber = query.PageSize * (query.PageNumber - 1);
            var pagedEdicoes = await edicoes.Skip(skipNumber).Take(query.PageSize).ToListAsync();

            return (pagedEdicoes, totalCount);
        }

        public async Task<(List<Edicao> Edicoes, int TotalCount)> GetEdicoesBySerieIdAsync(int serieId, EdicaoQueryObject query)
        {
            var edicoes = _context
            .Edicoes
            .Include(e => e.Serie)
            .Where(e => e.SerieId == serieId)
            .OrderBy(e => e.Id).AsQueryable();

            if (!string.IsNullOrWhiteSpace(query.Numero))
            {
                edicoes = edicoes.Where(e => e.Numero.Contains(query.Numero));
            }

            edicoes = edicoes.ApplySort(query.SortBy, query.IsDescending);


            var totalCount = await edicoes.CountAsync();
            var skipNumber = query.PageSize * (query.PageNumber - 1);
            var pagedEdicoes = await edicoes.Skip(skipNumber).Take(query.PageSize).ToListAsync();

            return (pagedEdicoes, totalCount);
        }

        public async Task<Edicao?> UpdateEdicaoAsync(int id, Edicao edicaoModel)
        {
            var existingEdicao = await _context.Edicoes.FirstOrDefaultAsync(e => e.Id == id);

            if (existingEdicao == null)
            {
                return null;
            }

            existingEdicao.FotoCapa = edicaoModel.FotoCapa;
            existingEdicao.Numero = edicaoModel.Numero;
            existingEdicao.UnMonetaria = edicaoModel.UnMonetaria;
            existingEdicao.Preco = edicaoModel.Preco;
            existingEdicao.DataLancamento = edicaoModel.DataLancamento;
            

            await _context.SaveChangesAsync();

            return existingEdicao;
        }
    }
}