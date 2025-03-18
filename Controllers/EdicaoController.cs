using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using tcc1_api.Data;
using tcc1_api.Dtos.Edicao;
using tcc1_api.Helpers;
using tcc1_api.Interfaces;
using tcc1_api.Mappers;

namespace tcc1_api.Controllers
{
    [ApiController]
    [Route("api/edicao")]
    public class EdicaoController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private readonly IEdicaoRepository _edicaoRepo;
        public EdicaoController(ApplicationDbContext context, IEdicaoRepository edicaoRepo)
        {
            _edicaoRepo = edicaoRepo;
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> GetEdicoes([FromQuery] EdicaoQueryObject query)
        {
            var (edicoes, totalCount) = await _edicaoRepo.GetEdicoesAsync(query);
            var edicoesDto = edicoes.Select(e => e.ToEdicaoWithSerieDto(e.Serie?.NomeInter ?? string.Empty)).ToList();

            // return Ok(edicoesDto);
            var paginationResponse = new PaginationResponse<EdicaoDto>(
                edicoesDto, 
                query.PageNumber, 
                query.PageSize, 
                totalCount
            );

            return Ok(paginationResponse);
        }

        [HttpGet("serieId/{serieId:int}")]
        public async Task<IActionResult> GetEdicoesBySerieId( [FromRoute] int serieId, [FromQuery] EdicaoQueryObject query)
        {
            var (edicoes, totalCount) = await _edicaoRepo.GetEdicoesBySerieIdAsync(serieId, query);
            var edicoesDto = edicoes.Select(e => e.ToEdicaoWithSerieDto(e.Serie?.NomeInter ?? string.Empty)).ToList();

            // return Ok(edicoesDto);
            var paginationResponse = new PaginationResponse<EdicaoDto>(
                edicoesDto, 
                query.PageNumber, 
                query.PageSize, 
                totalCount
            );

            return Ok(paginationResponse);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetEdicaoById([FromRoute]int id)
        {
            var edicao = await _edicaoRepo.GetEdicaoByIdAsync(id);

            if (edicao == null)
            {
                return NotFound();
            }

            return Ok(edicao.ToEdicaoWithSerieDto(edicao.Serie?.NomeInter ?? string.Empty));
        }

        [HttpPost("create/{serieId:int}")]
        public async Task<IActionResult> CreateEdicao([FromRoute]int serieId ,[FromBody] CreateEdicaoRequestDto edicaoDto)
        {
            var edicaoModel = edicaoDto.ToEdicaoFromCreateDTO(serieId);

            await _edicaoRepo.CreateEdicaoAsync(edicaoModel);

            return CreatedAtAction(nameof(GetEdicaoById), new { id = edicaoModel.SerieId }, edicaoModel.ToEdicaoDto());
        }

        [HttpPut("update/{id:int}")]
        public async Task<IActionResult> UpdateEdicao([FromRoute]int id, [FromBody] UpdateEdicaoRequestDto updateEdicaoDto)
        {
            var edicaoModel = await _edicaoRepo.UpdateEdicaoAsync(id, updateEdicaoDto.ToEdicaoFromUpdateDTO(id));

            if (edicaoModel == null)
            {
                return NotFound();
            }

            return Ok(edicaoModel.ToEdicaoDto());
        }

        [HttpDelete("delete/{id:int}")]
        public async Task<IActionResult> DeleteEdicao([FromRoute]int id)
        {
            var edicaoModel = await _edicaoRepo.DeleteEdicaoAsync(id);

            if (edicaoModel == null)
            {
                return NotFound();
            }

            return NoContent();
        }
    }
}