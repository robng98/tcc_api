using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using tcc1_api.Data;
using tcc1_api.Dtos.Exemplar;
using tcc1_api.Extensions;
using tcc1_api.Helpers;
using tcc1_api.Interfaces;
using tcc1_api.Mappers;
using tcc1_api.Models;

namespace tcc1_api.Controllers
{
    [Route("api/exemplar")]
    [ApiController]
    public class ExemplarController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private readonly IExemplarRepository _exemplarRepo;
        private readonly UserManager<AppUser> _userManager;

        public ExemplarController(
            ApplicationDbContext context, 
            IExemplarRepository exemplarRepo, 
            UserManager<AppUser> userManager)
        {
            _context = context;
            _exemplarRepo = exemplarRepo;
            _userManager = userManager;
        }

        [HttpGet]
        [Authorize]
        public async Task<IActionResult> GetExemplares([FromQuery] ExemplarQueryObject query)
        {
            var username = User.GetUsername();
            var appUser = await _userManager.FindByNameAsync(username);
            
            if (appUser == null)
            {
                return Unauthorized("User not found");
            }

            var (exemplares, totalCount) = await _exemplarRepo.GetExemplaresAsync(query, appUser.Id);
            var exemplaresDto = exemplares.Select(e => e.ToExemplarDto()).ToList();
            
            var paginationResponse = new PaginationResponse<ExemplarDto>(
                exemplaresDto,
                query.PageNumber,
                query.PageSize,
                totalCount
            );

            return Ok(paginationResponse);
        }

        [HttpGet("{id}")]
        [Authorize]
        public async Task<IActionResult> GetExemplarById([FromRoute]int id)
        {
            var username = User.GetUsername();
            var appUser = await _userManager.FindByNameAsync(username);
            
            if (appUser == null)
            {
                return Unauthorized("User not found");
            }

            var exemplar = await _exemplarRepo.GetExemplarByIdAsync(id, appUser.Id);

            if (exemplar == null)
            {
                return NotFound();
            }

            return Ok(exemplar.ToExemplarDto());
        }

        [HttpPost("create/")]
        [Authorize]
        public async Task<IActionResult> CreateExemplar([FromBody] CreateExemplarRequestDto exemplarDto)
        {
            var username = User.GetUsername();
            var appUser = await _userManager.FindByNameAsync(username);
            
            // Verify that the colecao belongs to the current user
            var colecao = await _context.Colecoes.FindAsync(exemplarDto.ColecaoId);
            if (colecao == null || colecao.AppUserId != appUser.Id)
            {
                return Unauthorized("You don't have access to this collection");
            }

            var exemplarModel = exemplarDto.ToExemplarFromCreateDTO();

            await _exemplarRepo.CreateExemplarAsync(exemplarModel);

            return CreatedAtAction(nameof(GetExemplarById), new { id = exemplarModel.Id }, exemplarModel.ToExemplarDto());
        }

        [HttpPut("update/{exemplarId:int}")]
        [Authorize]
        public async Task<IActionResult> UpdateExemplar([FromRoute]int exemplarId, [FromBody] UpdateExemplarRequestDto updateExemplarDto)
        {
            var username = User.GetUsername();
            var appUser = await _userManager.FindByNameAsync(username);
            
            if (appUser == null)
            {
                return Unauthorized("User not found");
            }

            var exemplarModel = updateExemplarDto.ToExemplarFromUpdateDTO();

            var updatedExemplar = await _exemplarRepo.UpdateExemplarAsync(exemplarId, exemplarModel, appUser.Id);

            if (updatedExemplar == null)
            {
                return NotFound("Exemplar not found or you don't have access to it");
            }

            return Ok(updatedExemplar.ToExemplarDto());
        }

        [HttpDelete("delete/{id:int}")]
        [Authorize]
        public async Task<IActionResult> DeleteExemplar([FromRoute]int id)
        {
            var username = User.GetUsername();
            var appUser = await _userManager.FindByNameAsync(username);
            
            if (appUser == null)
            {
                return Unauthorized("User not found");
            }

            var deletedExemplar = await _exemplarRepo.DeleteExemplarAsync(id, appUser.Id);

            if (deletedExemplar == null)
            {
                return NotFound("Exemplar not found or you don't have access to it");
            }

            return NoContent();
        }
    }
}