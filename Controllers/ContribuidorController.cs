using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using tcc1_api.Data;
using tcc1_api.Dtos.Contribuidor;
using tcc1_api.Helpers;
using tcc1_api.Interfaces;
using tcc1_api.Mappers;

namespace tcc1_api.Controllers
{
    [ApiController]
    [Route("api/contribuidor")]
    public class ContribuidorController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private readonly IContribuidorRepository _contribuidorRepo;

        public ContribuidorController(ApplicationDbContext context, IContribuidorRepository contribuidorRepo)
        {
            _context = context;
            _contribuidorRepo = contribuidorRepo;
        }

        [HttpGet]
        public async Task<ActionResult> GetContribuidores([FromQuery] ContribuidorQueryObject query)
        {
            var (contribuidores, totalCount) = await _contribuidorRepo.GetContribuidoresAsync(query);
            var contribuidoresDto = contribuidores.Select(e => e.ToContribuidorDto()).ToList();
            
            var paginationResponse = new PaginationResponse<ContribuidorDto>(
                contribuidoresDto,
                query.PageNumber,
                query.PageSize,
                totalCount
            );
            
            return Ok(paginationResponse);
        }        

        [HttpGet("{id}")]
        public async Task<IActionResult> GetContribuidorById([FromRoute]int id)
        {
            var contribuidor = await _contribuidorRepo.GetContribuidorByIdAsync(id);

            if (contribuidor == null)
            {
                return NotFound();
            }

            return Ok(contribuidor.ToContribuidorDto());
        }

        [HttpPost("create")]
        public async Task<IActionResult> CreateContribuidor([FromBody] CreateContribuidorRequestDto contribuidorDto)
        {
            var contribuidorModel = contribuidorDto.ToContribuidorFromCreateContribuidorDTO();
            await _contribuidorRepo.CreateContribuidorAsync(contribuidorModel);

            return CreatedAtAction(nameof(GetContribuidorById), new { id = contribuidorModel.Id }, contribuidorModel.ToContribuidorDto());
        }

        [HttpPut("update/{id:int}")]
        public async Task<IActionResult> UpdateContribuidor([FromRoute]int id, [FromBody] UpdateContribuidorRequestDto updateContribuidorDto)
        {
            var contribuidorModel = await _contribuidorRepo.UpdateContribuidorAsync(id, updateContribuidorDto);

            if (contribuidorModel == null)
            {
                return NotFound();
            }

            return Ok(contribuidorModel.ToContribuidorDto());
        }

        [HttpDelete("delete/{id:int}")]
        public async Task<IActionResult> DeleteContribuidor([FromRoute]int id)
        {
            var contribuidorModel = await _contribuidorRepo.DeleteContribuidorAsync(id);

            if (contribuidorModel == null)
            {
                return NotFound();
            }

            return NoContent();
        }

    }
}