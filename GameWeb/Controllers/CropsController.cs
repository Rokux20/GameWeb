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
    public class CropsController : ControllerBase
    {
        private readonly ICropsService _cropsService;
        public CropsController(ICropsService cropsService)
        {
            _cropsService = cropsService;
        }

        [HttpGet]
        public async Task<ActionResult<List<Crops>>> GetCrops()
        {
            return Ok(await _cropsService.GetCrops());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Crops>> GetCropId(int id)
        {
            var crop = await _cropsService.GetCropId(id);

            if (crop == null)
            {
                return NotFound();
            }

            return Ok(crop);
        }

        [HttpPost]
        public async Task<ActionResult<Crops>> AddCrop([FromBody] Crops crop)
        {
            return Ok(await _cropsService.AddCrop(crop.CropName, crop.FarmId));
        }

        [HttpPut("{id}")]
            public async Task<ActionResult<Crops>> UpdateCrop(int id, [FromBody] Crops crop)
        {
            try
            {
                return Ok(await _cropsService.UpdateCrop(id, crop.CropName, crop.FarmId));
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<Crops>> DeleteCrop(int id)
        {
            var crop = await _cropsService.DeleteCrop(id);
            if (crop == null)
            {
                return NotFound();
            }
            return Ok(crop);
        }
    }
}
