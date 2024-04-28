using GameWeb.Context;
using GameWeb.Models;
using Microsoft.EntityFrameworkCore;

namespace GameWeb.Repositories
{
    public interface IDevicesTypeEnergyRepository
    {
        Task<List<DevicesTypeEnergy>> GetDevicesTypeEnergy();
        Task<DevicesTypeEnergy> GetDeviceTypeEnergyId(int id);
        Task<DevicesTypeEnergy> AddDeviceTypeEnergy(int DeviceId, int TypeEnergyId);
        Task<DevicesTypeEnergy> UpdateDeviceTypeEnergy(DevicesTypeEnergy deviceTypeEnergy);
        Task<DevicesTypeEnergy> DeleteDeviceTypeEnergy(int id);

    }
    public class DevicesTypeEnergyRepository : IDevicesTypeEnergyRepository
    {
        private readonly FarmDbContext _context;

        public DevicesTypeEnergyRepository(FarmDbContext context)
        {
            _context = context;
        }

        public async Task<List<DevicesTypeEnergy>> GetDevicesTypeEnergy()
        {
            return await _context.DevicesTypeEnergy.ToListAsync();
        }

        public async Task<DevicesTypeEnergy> GetDeviceTypeEnergyId(int id)
        {
            return await _context.DevicesTypeEnergy.FindAsync(id);
        }

        public async Task<DevicesTypeEnergy> AddDeviceTypeEnergy(int DeviceId, int TypeEnergyId)
        {
            var deviceTypeEnergy = new DevicesTypeEnergy
            {
                DeviceId = DeviceId,
                TypeEnergyId = TypeEnergyId
            };

            await _context.DevicesTypeEnergy.AddAsync(deviceTypeEnergy);
            _context.SaveChanges();
            return deviceTypeEnergy;
        }

        public async Task<DevicesTypeEnergy> UpdateDeviceTypeEnergy(DevicesTypeEnergy deviceTypeEnergy)
        {
            _context.Entry(deviceTypeEnergy).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return deviceTypeEnergy;
        }

        public async Task<DevicesTypeEnergy> DeleteDeviceTypeEnergy(int id)
        {
            var deviceTypeEnergy = await _context.DevicesTypeEnergy.FindAsync(id);
            if (deviceTypeEnergy == null)
            {
                return null;
            }

            _context.DevicesTypeEnergy.Remove(deviceTypeEnergy);
            await _context.SaveChangesAsync();
            return deviceTypeEnergy;
        }
    }
}
