using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using tcc1_api.Data;
using tcc1_api.Dtos.Editora;
using tcc1_api.Extensions;
using tcc1_api.Helpers;
using tcc1_api.Interfaces;
using tcc1_api.Mappers;

namespace tcc1_api.Controllers
{   
    [Route("api/editora")]
    [ApiController]
    public class EditoraController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private readonly IEditoraRepository _editoraRepo;
        public EditoraController(ApplicationDbContext context, IEditoraRepository editoraRepo)
        {
            _editoraRepo = editoraRepo;
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> GetEditoras([FromQuery]EditoraQueryObject query)
        {
            var (editoras, totalCount) = await _editoraRepo.GetEditorasAsync(query);
            var editorasDto = editoras.Select(e => e.ToEditoraDto()).AsQueryable();
            // var editorasDto = editoras.Select(e => e.ToEditoraDto()).ToList();

            var sortedEditorasDtos = editorasDto.ApplySort(query.SortBy, query.IsDescending).ToList();

            var paginationResponse = new PaginationResponse<EditoraDto>(
                sortedEditorasDtos,
                query.PageNumber,
                query.PageSize,
                totalCount
            );

            return Ok(paginationResponse);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetEditoraById([FromRoute]int id)
        {
            var editora = await _editoraRepo.GetEditoraByIdAsync(id);

            if (editora == null)
            {
                return NotFound();
            }

            return Ok(editora.ToEditoraDto());
        }

        [HttpPost("create")]
        public async Task<IActionResult> CreateEditora([FromBody] CreateEditoraRequestDto editoraDto)
        {
            var editoraModel = editoraDto.ToEditoraFromCreateEditoraDTO();
            await _editoraRepo.CreateEditoraAsync(editoraModel);

            return CreatedAtAction(nameof(GetEditoraById), new { id = editoraModel.Id }, editoraModel.ToEditoraDto());
        }

        [HttpPut("update/{id:int}")]
        public async Task<IActionResult> UpdateEditora([FromRoute]int id, [FromBody] UpdateEditoraRequestDto updateEditoraDto)
        {
            var editoraModel = await _editoraRepo.UpdateEditoraAsync(id, updateEditoraDto);

            if (editoraModel == null)
            {
                return NotFound();
            }

            return Ok(editoraModel.ToEditoraDto());
        }

        [HttpDelete("delete/{id:int}")]
        public async Task<IActionResult> DeleteEditora([FromRoute]int id)
        {
            var editoraModel = await _editoraRepo.DeleteEditoraAsync(id);

            if (editoraModel == null)
            {
                return NotFound();
            }

            return NoContent();
        }

    }
}