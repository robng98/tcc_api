using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using tcc1_api.Data;
using tcc1_api.Dtos.Colecao;
using tcc1_api.Extensions;
using tcc1_api.Helpers;
using tcc1_api.Interfaces;
using tcc1_api.Mappers;
using tcc1_api.Models;

namespace tcc1_api.Controllers
{
    [Route("api/colecao")]
    [ApiController]
    public class ColecaoController : ControllerBase
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly IColecaoRepository _colecaoRepo;
        
        public ColecaoController
        (UserManager<AppUser> userManager,
        IColecaoRepository colecaoRepo)
        {
            _userManager = userManager;
            _colecaoRepo = colecaoRepo;
        }

        [HttpGet]
        [Authorize]
        public async Task<IActionResult> GetUserColecoes([FromQuery] ColecaoQueryObject query)
        {
            var username = User.GetUsername();
            var appUser = await _userManager.FindByNameAsync(username);
            
            var (colecoes, totalCount) = await _colecaoRepo.GetUserColecoes(appUser, query);
            var colecoesDto = colecoes.Select(c => c.ToColecaoDto()).ToList();
            
            var paginationResponse = new PaginationResponse<ColecaoDto>(
                colecoesDto,
                query.PageNumber,
                query.PageSize,
                totalCount
            );
            
            return Ok(paginationResponse);
        }

        [HttpGet("{colecaoId}/statistics")]
        [Authorize]
        public async Task<IActionResult> GetColecaoStatistics( [FromRoute] int colecaoId)
        {
            var username = User.GetUsername();
            var appUser = await _userManager.FindByNameAsync(username);
            
            // First check if the collection belongs to the user
            var userColecoes = await _colecaoRepo.GetUserColecoes(appUser);
            if (!userColecoes.Any(c => c.Id == colecaoId))
            {
                return NotFound("Coleção não encontrada ou não pertence ao usuário.");
            }
            
            var colecao = await _colecaoRepo.GetColecaoWithDetailsAsync(colecaoId);
            if (colecao == null)
            {
                return NotFound("Coleção não encontrada.");
            }

            // Get distinct Series, Editoras and Generos
            var series = colecao.Exemplares
                .Where(e => e.Edicao?.Serie != null)
                .Select(e => e.Edicao.Serie)
                .GroupBy(s => s.Id)
                .Select(g => g.First())
                .ToList();
            
            var editoras = series
                .Where(s => s.Editora != null)
                .Select(s => s.Editora)
                .GroupBy(e => e.Id)
                .Select(g => g.First())
                .ToList();
            
            var generos = series
                .SelectMany(s => s.Generos)
                .GroupBy(g => g.Id)
                .Select(g => g.First())
                .ToList();
            
            // Calculate most popular contributors by role
            var roteiristaGroup = colecao.Exemplares
                .Where(e => e.Edicao != null)
                .SelectMany(e => e.Edicao.Contribuicoes)
                .Where(c => c.Funcao == "Roteirista")
                .GroupBy(c => c.Contribuidor.Nome)
                .OrderByDescending(g => g.Count())
                .FirstOrDefault();
            
            var desenhistaGroup = colecao.Exemplares
                .Where(e => e.Edicao != null)
                .SelectMany(e => e.Edicao.Contribuicoes)
                .Where(c => c.Funcao == "Desenhista")
                .GroupBy(c => c.Contribuidor.Nome)
                .OrderByDescending(g => g.Count())
                .FirstOrDefault();
            
            var mangakaGroup = colecao.Exemplares
                .Where(e => e.Edicao != null)
                .SelectMany(e => e.Edicao.Contribuicoes)
                .Where(c => c.Funcao == "Mangaka")
                .GroupBy(c => c.Contribuidor.Nome)
                .OrderByDescending(g => g.Count())
                .FirstOrDefault();
            
            // Calculate most popular genre
            var generoGroup = series
                .SelectMany(s => s.Generos)
                .GroupBy(g => g.Tipo)
                .OrderByDescending(g => g.Count())
                .FirstOrDefault();
            
            // Calculate most popular editora
            var editoraGroup = series
                .Where(s => s.Editora != null)
                .GroupBy(s => s.Editora.Nome)
                .OrderByDescending(g => g.Count())
                .FirstOrDefault();
            
            // Calculate most popular demografia
            var demografiaGroup = series
                .Where(s => s.Manga != null && !string.IsNullOrEmpty(s.Manga.Demografia))
                .GroupBy(s => s.Manga.Demografia)
                .OrderByDescending(g => g.Count())
                .FirstOrDefault();

            // Calculate total amount of unique Edicoes
            var totalEdicoes = colecao.Exemplares
                .Where(e => e.Edicao != null)
                .Select(e => e.Edicao.Id)
                .Distinct()
                .Count();
            
            // Calculate total amount of Exemplares
            var totalExemplares = colecao.Exemplares.Count;
            
            var statistics = new ColecaoStatisticsDto
            {
                TotalSeries = series.Count,
                TotalEditoras = editoras.Count,
                TotalGeneros = generos.Count,
                TotalEdicoes = totalEdicoes,
                TotalExemplares = totalExemplares,
                
                // Most popular entities
                MostPopularRoteirista = roteiristaGroup?.Key,
                MostPopularDesenhista = desenhistaGroup?.Key,
                MostPopularMangaka = mangakaGroup?.Key,
                MostPopularGenero = generoGroup?.Key,
                MostPopularEditora = editoraGroup?.Key,
                MostPopularDemografia = demografiaGroup?.Key
            };
            
            return Ok(statistics);
        }

        [HttpPost("create/{nome}")]	
        [Authorize]
        public async Task<IActionResult> CreateColecao( [FromRoute] string nome)
        {
            if (string.IsNullOrEmpty(nome))
            {
                return BadRequest("Nome da coleção não pode ser vazio.");
            }
            var username = User.GetUsername();
            var appUser = await _userManager.FindByNameAsync(username);
            var colecaoModel = new Colecao
            {
                NomeColecao = nome,
                AppUserId = appUser.Id
            };
            await _colecaoRepo.CreateColecaoAsync(colecaoModel);

            if (colecaoModel == null)
            {
                return StatusCode(500, "Coleção não pode ser criada.");
            }
            else
            {
                return Created();
            }
        }
        
        [HttpDelete("delete/{colecaoId}")]
        [Authorize]
        public async Task<IActionResult> DeleteColecao( [FromRoute] int colecaoId)
        {
            var username = User.GetUsername();
            var appUser = await _userManager.FindByNameAsync(username);

            var userColecao = await _colecaoRepo.GetUserColecoes(appUser);
            var filteredColecao = userColecao.Where(c => c.Id == colecaoId).ToList();
            if (filteredColecao.Count() == 1)
            {
                await _colecaoRepo.DeleteColecaoAsync(appUser, colecaoId);
            }
            else
            {
                return NotFound("Coleção não encontrada.");
            }

            return NoContent();
        }
        
    }
}