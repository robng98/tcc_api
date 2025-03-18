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
        public async Task<IActionResult> CreateContribuicao(int contribuidorId, int edicaoId, string funcao)
        {
            var edicao = await _edicaoRepo.GetEdicaoByIdAsync(edicaoId);
            var contribuidor = await _contribuidorRepo.GetContribuidorByIdAsync(contribuidorId);

            if (edicao == null || contribuidor == null)
            {
                return NotFound("Edição ou Contribuidor não encontrado");
            }

            var contribuiModel = new Contribui
            {
                ContribuidorId = contribuidorId,
                EdicaoId = edicaoId,
                Funcao = funcao
            };

            await _contribuiRepo.CreateContribuiAsync(contribuiModel);

            if(contribuiModel == null)
            {
                return StatusCode(500, "Contribuição não foi criada");
            }

            return Created();
        }

        [HttpDelete("delete")]
        public async Task<IActionResult> DeleteContribuicao(int contribuidorId, int edicaoId)
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