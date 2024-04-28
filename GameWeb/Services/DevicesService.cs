using GameWeb.Models;
using GameWeb.Repositories;

namespace GameWeb.Services
{
    public interface IDevicesService
    {
        Task<List<Devices>> GetDevices();
        Task<Devices> GetDeviceId(int id);
        Task<Devices> AddDevice(string DeviceName, string Consumer, int FarmId);
        Task<Devices> UpdateDevice(int DeviceId, string? DeviceName = null, string? Consumer = null, int? FarmId = null);
        Task<Devices> DeleteDevice(int id);
    }
    public class DevicesService : IDevicesService
    {
        private readonly IDevicesRepository _devicesRepository;

        public DevicesService(IDevicesRepository devicesRepository)
        {
            _devicesRepository = devicesRepository;
        }

        public async Task<List<Devices>> GetDevices()
        {
            return await _devicesRepository.GetDevices();
        }

        public async Task<Devices> GetDeviceId(int id)
        {
            return await _devicesRepository.GetDeviceId(id);
        }

        public async Task<Devices> AddDevice(string DeviceName, string Consumer, int FarmId)
        {
            return await _devicesRepository.AddDevice(DeviceName, Consumer, FarmId);
        }

        public async Task<Devices> UpdateDevice(int DeviceId, string? DeviceName = null, string? Consumer = null, int? FarmId = null)
        {
            var device = await _devicesRepository.GetDeviceId(DeviceId);
            if (device == null)
            {
                throw new Exception("Device not found");
            }

            if (DeviceName != null)
            {
                device.DeviceName = DeviceName;
            }

            if (Consumer != null)
            {
                device.Consumer = Consumer;
            }

            if (FarmId != null)
            {
                device.FarmId = (int)FarmId;
            }

            return await _devicesRepository.UpdateDevice(device);
        }

        public async Task<Devices> DeleteDevice(int id)
        {
            return await _devicesRepository.DeleteDevice(id);
        }
    }
}
