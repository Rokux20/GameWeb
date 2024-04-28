using GameWeb.Models;
using GameWeb.Repositories;

namespace GameWeb.Services
{
    public interface IDevicesTypeEnergyService
    {
        Task<List<DevicesTypeEnergy>> GetDevicesTypeEnergy();
        Task<DevicesTypeEnergy> GetDeviceTypeEnergyId(int id);
        Task<DevicesTypeEnergy> AddDeviceTypeEnergy(int DeviceId, int TypeEnergyId);
        Task<DevicesTypeEnergy> UpdateDeviceTypeEnergy(int DevicesEnergyId, int? DeviceId = null, int? TypeEnergyId = null);
        Task<DevicesTypeEnergy> DeleteDeviceTypeEnergy(int id);
    }
    public class DevicesTypeEnergyService : IDevicesTypeEnergyService
    {
        private readonly IDevicesTypeEnergyRepository _devicesTypeEnergyRepository;

        public DevicesTypeEnergyService(IDevicesTypeEnergyRepository devicesTypeEnergyRepository)
        {
            _devicesTypeEnergyRepository = devicesTypeEnergyRepository;
        }

        public async Task<List<DevicesTypeEnergy>> GetDevicesTypeEnergy()
        {
            return await _devicesTypeEnergyRepository.GetDevicesTypeEnergy();
        }

        public async Task<DevicesTypeEnergy> GetDeviceTypeEnergyId(int id)
        {
            return await _devicesTypeEnergyRepository.GetDeviceTypeEnergyId(id);
        }

        public async Task<DevicesTypeEnergy> AddDeviceTypeEnergy(int DeviceId, int TypeEnergyId)
        {
            return await _devicesTypeEnergyRepository.AddDeviceTypeEnergy(DeviceId, TypeEnergyId);
        }
        public async Task<DevicesTypeEnergy> UpdateDeviceTypeEnergy(int DevicesEnergyId, int? DeviceId = null, int? TypeEnergyId = null)
        {
            var deviceTypeEnergy = await _devicesTypeEnergyRepository.GetDeviceTypeEnergyId(DevicesEnergyId);
            if (deviceTypeEnergy == null)
            {
                throw new Exception("DeviceTypeEnergy not found");
            }

            if (DeviceId != null)
            {
                deviceTypeEnergy.DeviceId = (int)DeviceId;
            }

            if (TypeEnergyId != null)
            {
                deviceTypeEnergy.TypeEnergyId = (int)TypeEnergyId;
            }
            return await _devicesTypeEnergyRepository.UpdateDeviceTypeEnergy(deviceTypeEnergy);
        }
        public async Task<DevicesTypeEnergy> DeleteDeviceTypeEnergy(int id)
        {
            return await _devicesTypeEnergyRepository.DeleteDeviceTypeEnergy(id);
        }
    }
}
