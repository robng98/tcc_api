using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using tcc1_api.Data;
using tcc1_api.Dtos.Tankobon;
using tcc1_api.Helpers;
using tcc1_api.Interfaces;
using tcc1_api.Mappers;

namespace tcc1_api.Controllers
{
    [ApiController]
    [Route("api/tankobon")]
    public class TankobonController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private readonly ITankobonRepository _tankobonRepo;

        public TankobonController(ApplicationDbContext context, ITankobonRepository tankobonRepo)
        {
            _context = context;
            _tankobonRepo = tankobonRepo;
        }

        [HttpGet]
        public async Task<IActionResult> GetTankobons([FromQuery] TankobonQueryObject query)
        {
            var tankobon = await _tankobonRepo.GetTankobonsAsync(query);
            var tankobonDto = tankobon.Select(e => e.ToTankobonDto());

            return Ok(tankobonDto);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetTankobonById([FromRoute] int id)
        {
            var tankobon = await _tankobonRepo.GetTankobonByIdAsync(id);

            if (tankobon == null)
            {
                return NotFound();
            }

            return Ok(tankobon.ToTankobonDto());
        }

        [HttpGet("edicaoId/{edicaoId}")]
        public async Task<IActionResult> GetTankobonByEdicaoId([FromRoute] int edicaoId)
        {
            var tankobon = await _tankobonRepo.GetTankobonByEdicaoIdAsync(edicaoId);

            if (tankobon == null)
            {
                return NotFound();
            }

            return Ok(tankobon.ToTankobonDto());
        }

        [HttpPost("create/{edicaoId:int}")]
        public async Task<IActionResult> CreateTankobon([FromRoute] int edicaoId, [FromBody] CreateTankobonRequestDto tankobonDto)
        {
            var tankobonModel = tankobonDto.ToTankobonFromCreateDTO(edicaoId);

            await _tankobonRepo.CreateTankobonAsync(tankobonModel);

            return CreatedAtAction(nameof(GetTankobonById), new { id = tankobonModel.EdicaoId }, tankobonModel.ToTankobonDto());
        }

        [HttpPut("update/{id:int}")]
        public async Task<IActionResult> UpdateTankobon([FromRoute] int id, [FromBody] UpdateTankobonRequestDto updateTankobonDto)
        {
            var tankobonModel = await _tankobonRepo.UpdateTankobonAsync(id, updateTankobonDto.ToTankobonFromUpdateDTO(id));

            if (tankobonModel == null)
            {
                return NotFound();
            }

            return Ok(tankobonModel.ToTankobonDto());
        }

        [HttpDelete("delete/{id:int}")]
        public async Task<IActionResult> DeleteTankobon([FromRoute] int id)
        {
            var tankobonModel = await _tankobonRepo.DeleteTankobonAsync(id);

            if (tankobonModel == null)
            {
                return NotFound();
            }

            return Ok(tankobonModel.ToTankobonDto());
        }


    }
}