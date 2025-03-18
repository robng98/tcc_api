using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using tcc1_api.Dtos.Editora;
using tcc1_api.Helpers;
using tcc1_api.Models;

namespace tcc1_api.Interfaces
{
    public interface IEditoraRepository
    {
        Task<(List<Editora> Editoras, int TotalCount)> GetEditorasAsync(EditoraQueryObject query);
        Task<Editora?> GetEditoraByIdAsync(int id);
        Task<Editora> CreateEditoraAsync(Editora editoraModel);
        Task<Editora?> UpdateEditoraAsync(int id, UpdateEditoraRequestDto updateEditoraDto);
        Task<Editora?> DeleteEditoraAsync(int id);
    }
}