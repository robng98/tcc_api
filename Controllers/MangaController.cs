using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using tcc1_api.Data;
using tcc1_api.Dtos.Manga;
using tcc1_api.Helpers;
using tcc1_api.Interfaces;
using tcc1_api.Mappers;

namespace tcc1_api.Controllers
{
    [ApiController]
    [Route("api/manga")]
    public class MangaController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private readonly IMangaRepository _mangaRepo;

        public MangaController(ApplicationDbContext context, IMangaRepository mangaRepo)
        {
            _context = context;
            _mangaRepo = mangaRepo;
        }

        [HttpGet]
        public async Task<IActionResult> GetMangas([FromQuery] MangaQueryObject query)
        {
            var manga = await _mangaRepo.GetMangasAsync(query);
            var mangaDto = manga.Select(e => e.ToMangaDto());

            return Ok(mangaDto);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetMangaById([FromRoute] int id)
        {
            var manga = await _mangaRepo.GetMangaByIdAsync(id);

            if (manga == null)
            {
                return NotFound();
            }

            return Ok(manga.ToMangaDto());
        }

        [HttpPost("create/{serieId:int}")]
        public async Task<IActionResult> CreateManga([FromRoute] int serieId, [FromBody] CreateMangaRequestDto mangaDto)
        {
            var mangaModel = mangaDto.ToMangaFromCreateDTO(serieId);

            await _mangaRepo.CreateMangaAsync(mangaModel);

            return CreatedAtAction(nameof(GetMangaById), new { id = mangaModel.SerieId }, mangaModel.ToMangaDto());
        }

        [HttpPut("update/{id:int}")]
        public async Task<IActionResult> UpdateManga([FromRoute] int id, [FromBody] UpdateMangaRequestDto updateMangaDto)
        {
            var mangaModel = await _mangaRepo.UpdateMangaAsync(id, updateMangaDto.ToMangaFromUpdateDTO(id));

            if (mangaModel == null)
            {
                return NotFound();
            }

            return Ok(mangaModel.ToMangaDto());
        }

        [HttpDelete("delete/{id:int}")]
        public async Task<IActionResult> DeleteManga([FromRoute] int id)
        {
            var mangaModel = await _mangaRepo.DeleteMangaAsync(id);

            if (mangaModel == null)
            {
                return NotFound();
            }

            return Ok(mangaModel.ToMangaDto());
        }


    }
}