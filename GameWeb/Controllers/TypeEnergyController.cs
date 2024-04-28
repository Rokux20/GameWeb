using GameWeb.Context;
using GameWeb.Models;
using GameWeb.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GameWeb.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TypeEnergyController : ControllerBase
    {
        private readonly ITypeEnergyService _typeEnergyService;
        public TypeEnergyController(ITypeEnergyService typeEnergyService)
        {
            _typeEnergyService = typeEnergyService;
        }

        [HttpGet]
        public async Task<ActionResult<List<TypeEnergy>>> GetTypeEnergy()
        {
            return Ok(await _typeEnergyService.GetTypeEnergy());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<TypeEnergy>> GetTypeEnergyId(int id)
        {
            var typeEnergy = await _typeEnergyService.GetTypeEnergyId(id);

            if (typeEnergy == null)
            {
                return NotFound();
            }

            return Ok(typeEnergy);
        }

        [HttpPost]
        public async Task<ActionResult<TypeEnergy>> AddTypeEnergy([FromBody] TypeEnergy typeEnergy)
        {
            return Ok(await _typeEnergyService.AddTypeEnergy(typeEnergy.TypeEnergyName));
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<TypeEnergy>> UpdateTypeEnergy(int id, [FromBody] TypeEnergy typeEnergy)
        {
            try
            {
                return Ok(await _typeEnergyService.UpdateTypeEnergy(id, typeEnergy.TypeEnergyName));
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<TypeEnergy>> DeleteTypeEnergy(int id)
        {
           var typeEnergy = await _typeEnergyService.DeleteTypeEnergy(id);
            if (typeEnergy == null)
            {
                return NotFound();
            }
            return Ok(typeEnergy);
        }
    }
}
