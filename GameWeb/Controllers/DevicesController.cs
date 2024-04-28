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
    public class DevicesController : ControllerBase
    {
        private readonly IDevicesService _devicesService;
        public DevicesController(IDevicesService devicesService)
        {
            _devicesService = devicesService;
        }

        [HttpGet]
        public async Task<ActionResult<List<Devices>>> GetDevices()
        {
            return Ok(await _devicesService.GetDevices());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Devices>> GetDeviceId(int id)
        {
            var device = await _devicesService.GetDeviceId(id);

            if (device == null)
            {
                return NotFound();
            }

            return Ok(device);
        }

        [HttpPost]
        public async Task<ActionResult<Devices>> AddDevice([FromBody] Devices device)
        {
            return Ok(await _devicesService.AddDevice(device.DeviceName, device.Consumer, device.FarmId));
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<Devices>> UpdateDevice(int id, [FromBody] Devices device)
        {
            try
            {
                return Ok(await _devicesService.UpdateDevice(id, device.DeviceName, device.Consumer, device.FarmId));
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<Devices>> DeleteDevice(int id)
        {
            var device = await _devicesService.DeleteDevice(id);
            if (device == null)
            {
                return NotFound();
            }
            return Ok(device);
        }
    }
}
