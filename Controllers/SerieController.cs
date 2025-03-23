using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using tcc1_api.Data;
using tcc1_api.Dtos.Serie;
using tcc1_api.Extensions;
using tcc1_api.Helpers;
using tcc1_api.Interfaces;
using tcc1_api.Mappers;

namespace tcc1_api.Controllers
{
    [ApiController]
    [Route("api/serie")]
    public class SerieController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private readonly ISerieRepository _serieRepo;
        public SerieController(ApplicationDbContext context, ISerieRepository serieRepo)
        {
            _serieRepo = serieRepo;
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> GetSeries([FromQuery] SerieQueryObject query)
        {
            var (series, totalCount) = await _serieRepo.GetSeriesAsync(query);
            var seriesDto = series.Select(e => e.ToSerieMangaDto()).AsQueryable();
            // var seriesDto = series.Select(e => e.ToSerieMangaDto()).ToList();

            var sortedSeriesDtos = seriesDto.ApplySort(query.SortBy, query.IsDescending).ToList();

            var paginationResponse = new PaginationResponse<SerieMangaDto>(
                sortedSeriesDtos,
                query.PageNumber,
                query.PageSize,
                totalCount
            );

            return Ok(paginationResponse);
        }

        [HttpGet("comics")]
        public async Task<IActionResult> GetSeriesComics([FromQuery] SerieQueryObject query)
        {
            var (series, totalCount) = await _serieRepo.GetSeriesComicsAsync(query);
            var seriesComicsDto = series.Select(e => e.ToSerieDto()).AsQueryable();
            
            var sortedSeriesComicsDtos = seriesComicsDto.ApplySort(query.SortBy, query.IsDescending).ToList();

            var paginationResponse = new PaginationResponse<SerieDto>(
                sortedSeriesComicsDtos,
                query.PageNumber,
                query.PageSize,
                totalCount
            );

            return Ok(paginationResponse);
        }

        [HttpGet("mangas")]
        public async Task<IActionResult> GetSeriesMangas([FromQuery] SerieQueryObject query)
        {
            var (series, totalCount) = await _serieRepo.GetSeriesMangasAsync(query);
            var seriesMangaDto = series.Select(e => e.ToSerieMangaDto()).AsQueryable();

            var sortedSeriesMangaDtos = seriesMangaDto.ApplySort(query.SortBy, query.IsDescending).ToList();

            var paginationResponse = new PaginationResponse<SerieMangaDto>(
                sortedSeriesMangaDtos,
                query.PageNumber,
                query.PageSize,
                totalCount
            );

            return Ok(paginationResponse);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetSerieById([FromRoute]int id)
        {
            var serie = await _serieRepo.GetSerieByIdAsync(id);

            if (serie == null)
            {
                return NotFound();
            }

            return Ok(serie.ToSerieMangaDto());
        }

        [HttpPost("create/{editoraId:int}")]
        public async Task<IActionResult> CreateSerie([FromRoute]int editoraId ,[FromBody] CreateSerieRequestDto serieDto)
        {
            var serieModel = serieDto.ToSerieFromCreateDTO(editoraId);

            await _serieRepo.CreateSerieAsync(serieModel);

            return CreatedAtAction(nameof(GetSerieById), new { id = serieModel.EditoraId }, serieModel.ToSerieDto());
        }

        [HttpPut("update/{id:int}")]
        public async Task<IActionResult> UpdateSerie([FromRoute]int id, [FromBody] UpdateSerieRequestDto updateSerieDto)
        {
            var serieModel = await _serieRepo.UpdateSerieAsync(id, updateSerieDto.ToSerieFromUpdateDTO(id));

            if (serieModel == null)
            {
                return NotFound();
            }

            return Ok(serieModel.ToSerieDto());
        }

        [HttpDelete("delete/{id:int}")]
        public async Task<IActionResult> DeleteSerie([FromRoute]int id)
        {
            var serieModel = await _serieRepo.DeleteSerieAsync(id);

            if (serieModel == null)
            {
                return NotFound();
            }

            return NoContent();
        }
    }
}