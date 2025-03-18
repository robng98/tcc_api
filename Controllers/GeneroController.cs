using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using tcc1_api.Data;
using tcc1_api.Dtos.Genero;
using tcc1_api.Helpers;
using tcc1_api.Interfaces;
using tcc1_api.Mappers;

namespace tcc1_api.Controllers
{
    [ApiController]
    [Route("api/genero")]
    public class GeneroController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private readonly IGeneroRepository _generoRepo;

        public GeneroController(ApplicationDbContext context, IGeneroRepository generoRepo)
        {
            _context = context;
            _generoRepo = generoRepo;
        }

        [HttpGet]
        public async Task<IActionResult> GetGeneros([FromQuery] GeneroQueryObject query)
        {
            var genero = await _generoRepo.GetGenerosAsync(query);
            var generoDto = genero.Select(e => e.ToGeneroDto());

            return Ok(generoDto);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetGeneroById([FromRoute]int id)
        {
            var genero = await _generoRepo.GetGeneroByIdAsync(id);

            if (genero == null)
            {
                return NotFound();
            }

            return Ok(genero.ToGeneroDto());
        }

        [HttpPost("create/{serieId:int}")]
        public async Task<IActionResult> CreateGenero([FromRoute]int serieId ,[FromBody] CreateGeneroRequestDto generoDto)
        {
            var generoModel = generoDto.ToGeneroFromCreateDTO(serieId);

            await _generoRepo.CreateGeneroAsync(generoModel);

            return CreatedAtAction(nameof(GetGeneroById), new { id = generoModel.SerieId }, generoModel.ToGeneroDto());
        }

        [HttpPut("update/{id:int}")]
        public async Task<IActionResult> UpdateSerie([FromRoute]int id, [FromBody] UpdateGeneroRequestDto updateGeneroDto)
        {
            var generoModel = await _generoRepo.UpdateGeneroAsync(id, updateGeneroDto.ToGeneroFromUpdateDTO(id));

            if (generoModel == null)
            {
                return NotFound();
            }

            return Ok(generoModel.ToGeneroDto());
        }

        [HttpDelete("delete/{id:int}")]
        public async Task<IActionResult> DeleteGenero([FromRoute]int id)
        {
            var generoModel = await _generoRepo.DeleteGeneroAsync(id);

            if (generoModel == null)
            {
                return NotFound();
            }

            return Ok(generoModel.ToGeneroDto());
        }

        
    }
}