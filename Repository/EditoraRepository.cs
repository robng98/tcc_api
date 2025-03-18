using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using tcc1_api.Data;
using tcc1_api.Dtos.Editora;
using tcc1_api.Extensions;
using tcc1_api.Helpers;
using tcc1_api.Interfaces;
using tcc1_api.Models;

namespace tcc1_api.Repository
{
    public class EditoraRepository : IEditoraRepository
    {
        private readonly ApplicationDbContext _context;

        public EditoraRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Editora> CreateEditoraAsync(Editora editoraModel)
        {
            await _context.Editoras.AddAsync(editoraModel);
            await _context.SaveChangesAsync();
            return editoraModel;
        }

        public async Task<Editora?> DeleteEditoraAsync(int id)
        {
            var editoraModel = await _context.Editoras.FirstOrDefaultAsync(e => e.Id == id);

            if (editoraModel == null)
            {
                return null;
            }

            _context.Editoras.Remove(editoraModel);
            await _context.SaveChangesAsync();

            return editoraModel;
        }

        public async Task<Editora?> GetEditoraByIdAsync(int id)
        {
            return await _context.Editoras
                .Include(e => e.Series)
                .FirstOrDefaultAsync(e => e.Id == id);
        }

        public async Task<(List<Editora> Editoras, int TotalCount)> GetEditorasAsync(EditoraQueryObject query)
        {
            var editoras = _context.Editoras
                .Include(e => e.Series) // Include Series collection
                .AsQueryable();

            // Apply filters if provided
            if (!string.IsNullOrWhiteSpace(query.Nome))
            {
                editoras = editoras.Where(e => e.Nome.Contains(query.Nome));
            }
            
            // Apply sorting using the extension method
            editoras = editoras.ApplySort(query.SortBy, query.IsDescending);
            
            // Get total count for pagination
            var totalCount = await editoras.CountAsync();
            
            // Apply pagination
            var skipNumber = query.PageSize * (query.PageNumber - 1);
            var pagedEditoras = await editoras
                .Skip(skipNumber)
                .Take(query.PageSize)
                .ToListAsync();
            
            return (pagedEditoras, totalCount);
        }

        public async Task<Editora?> UpdateEditoraAsync(int id, UpdateEditoraRequestDto updateEditoraDto)
        {
            var existingEditora = await _context.Editoras.FirstOrDefaultAsync(e => e.Id == id);

            if (existingEditora == null)
            {
                return null;
            }

            existingEditora.Nome = updateEditoraDto.Nome;
            existingEditora.AnoCriacao = updateEditoraDto.AnoCriacao;
            existingEditora.Logo = updateEditoraDto.Logo;

            await _context.SaveChangesAsync();

            return existingEditora;
        }
    }
}