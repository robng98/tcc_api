using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using tcc1_api.Data;
using tcc1_api.Dtos.Contribui;
using tcc1_api.Helpers;
using tcc1_api.Interfaces;
using tcc1_api.Models;

namespace tcc1_api.Controllers
{
    [ApiController]
    [Route("api/contribui")]
    public class ContribuiController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private readonly IEdicaoRepository _edicaoRepo;
        private readonly IContribuiRepository _contribuiRepo;
        private readonly IContribuidorRepository _contribuidorRepo;

        public ContribuiController
        (ApplicationDbContext context,
        IContribuiRepository contribuiRepo,
        IEdicaoRepository edicaoRepo,
        IContribuidorRepository contribuidorRepo)
        {
            _contribuiRepo = contribuiRepo;
            _edicaoRepo = edicaoRepo;
            _contribuidorRepo = contribuidorRepo;
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> GetContribuidoresEdicao([FromQuery] ContribuiQueryObject query)
        {
            var (contribuicoes, totalCount) = await _contribuiRepo.GetContribuidoresEdicaoAsync(query);

            var paginationResponse = new PaginationResponse<ContribuiNormalDto>(
                contribuicoes,
                query.PageNumber,
                query.PageSize,
                totalCount
            );

            return Ok(paginationResponse);
        }

        [HttpPost("create")]
        // public async Task<IActionResult> CreateContribuicao([FromBody] int contribuidorId, [FromBody] int edicaoId, [FromBody] string funcao)
        public async Task<IActionResult> CreateContribuicao([FromBody] CreateContribuiRequestDto contribuiRequestDto)
        {
            var edicao = await _edicaoRepo.GetEdicaoByIdAsync(contribuiRequestDto.EdicaoId);
            var contribuidor = await _contribuidorRepo.GetContribuidorByIdAsync(contribuiRequestDto.ContribuidorId);

            if (edicao == null || contribuidor == null)
            {
                return NotFound("Edição ou Contribuidor não encontrado");
            }

            if (!contribuiRequestDto.Funcao.Equals("roteirista", StringComparison.CurrentCultureIgnoreCase)
                && !contribuiRequestDto.Funcao.Equals("desenhista", StringComparison.CurrentCultureIgnoreCase)
                && !contribuiRequestDto.Funcao.Equals("arte-finalista", StringComparison.CurrentCultureIgnoreCase)
                && !contribuiRequestDto.Funcao.Equals("colorista", StringComparison.CurrentCultureIgnoreCase)
                && !contribuiRequestDto.Funcao.Equals("mangaká", StringComparison.CurrentCultureIgnoreCase))
            {
                return BadRequest("Função inválida");
            }

            var contribuiModel = new Contribui
            {
                ContribuidorId = contribuiRequestDto.ContribuidorId,
                EdicaoId = contribuiRequestDto.EdicaoId,
                Funcao = contribuiRequestDto.Funcao
            };

            await _contribuiRepo.CreateContribuiAsync(contribuiModel);

            if (contribuiModel == null)
            {
                return StatusCode(500, "Contribuição não foi criada");
            }

            return Created();
        }

        [HttpDelete("delete/{contribuidorId}/{edicaoId}")]
        public async Task<IActionResult> DeleteContribuicao([FromRoute] int contribuidorId, [FromRoute] int edicaoId)
        {
            var contribuiModel = await _contribuiRepo.DeleteContribuiAsync(contribuidorId, edicaoId);

            if (contribuiModel == null)
            {
                return NotFound();
            }

            return NoContent();
        }
    }
}