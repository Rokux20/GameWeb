using GameWeb.Models;
using GameWeb.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GameWeb.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DevicesTypeEnergyController : ControllerBase
    {
        private readonly IDevicesTypeEnergyService _devicesTypeEnergyService;
        public DevicesTypeEnergyController(IDevicesTypeEnergyService devicesTypeEnergyService)
        {
            _devicesTypeEnergyService = devicesTypeEnergyService;
        }

        [HttpGet]
        public async Task<ActionResult<List<DevicesTypeEnergy>>> GetDevicesTypeEnergy()
        {
            return Ok(await _devicesTypeEnergyService.GetDevicesTypeEnergy());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<DevicesTypeEnergy>> GetDeviceTypeEnergyId(int id)
        {
            var deviceTypeEnergy = await _devicesTypeEnergyService.GetDeviceTypeEnergyId(id);

            if (deviceTypeEnergy == null)
            {
                return NotFound();
            }

            return Ok(deviceTypeEnergy);
        }

        [HttpPost]
        public async Task<ActionResult<DevicesTypeEnergy>> AddDeviceTypeEnergy([FromBody] DevicesTypeEnergy deviceTypeEnergy)
        {
            return Ok(await _devicesTypeEnergyService.AddDeviceTypeEnergy(deviceTypeEnergy.DeviceId, deviceTypeEnergy.TypeEnergyId));
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<DevicesTypeEnergy>> UpdateDeviceTypeEnergy(int id, [FromBody] DevicesTypeEnergy deviceTypeEnergy)
        {
            try
            {
                return Ok(await _devicesTypeEnergyService.UpdateDeviceTypeEnergy(id, deviceTypeEnergy.DeviceId, deviceTypeEnergy.TypeEnergyId));
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<DevicesTypeEnergy>> DeleteDeviceTypeEnergy(int id)
        {
            var deviceTypeEnergy = await _devicesTypeEnergyService.DeleteDeviceTypeEnergy(id);
            if (deviceTypeEnergy == null)
            {
                return NotFound();
            }

            return Ok(deviceTypeEnergy);
        }
    }
}
