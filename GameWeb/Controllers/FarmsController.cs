using GameWeb.Context;
using GameWeb.Models;
using GameWeb.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace GameWeb.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FarmsController : ControllerBase
    {
        private readonly IFarmsService _farmsService;
        public FarmsController(IFarmsService farmsService)
        {
            _farmsService = farmsService;
        }

        [HttpGet]
        public async Task<ActionResult<List<Farms>>> GetFarms()
        {
            return Ok(await _farmsService.GetFarms());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Farms>> GetFarmId(int id)
        {
            var farm = await _farmsService.GetFarmId(id);

            if (farm == null)
            {
                return NotFound();
            }

            return Ok(farm);
        }

        [HttpPost]
        public async Task<ActionResult<Farms>> AddFarm([FromBody] Farms farm)
        {
            return Ok(await _farmsService.AddFarm(farm.FarmName));
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<Farms>> UpdateFarm(int id, [FromBody] Farms farm )
        {
                try
                {
                return Ok(await _farmsService.UpdateFarm(id, farm.FarmName));
                }
                catch (Exception ex)
                {
                    return NotFound(ex.Message);
                }
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<Farms>> DeleteFarm(int id)
        {
            var farm = await _farmsService.DeleteFarm(id);
            if (farm == null)
            {
                return NotFound();
            }

            return Ok(farm);
        }
    }
}