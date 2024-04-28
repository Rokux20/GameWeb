using GameWeb.Context;
using GameWeb.Models;
using Microsoft.EntityFrameworkCore;

namespace GameWeb.Repositories
{
    public interface IDevicesRepository
    {
        Task<List<Devices>> GetDevices();
        Task<Devices> GetDeviceId(int id);
        Task<Devices> AddDevice(string DeviceName, string Consumer, int Farmid);
        Task<Devices> UpdateDevice(Devices device);
        Task<Devices> DeleteDevice(int id);
    }

    public class DevicesRepository : IDevicesRepository
    {
        private readonly FarmDbContext _context;

        public DevicesRepository(FarmDbContext context)
        {
            _context = context;
        }

        public async Task<List<Devices>> GetDevices()
        {
            return await _context.Devices.ToListAsync();
        }

        public async Task<Devices> GetDeviceId(int id)
        {
            return await _context.Devices.FindAsync(id);
        }

        public async Task<Devices> AddDevice(string DeviceName, string Consumer, int Farmid)
        {
            var device = new Devices
            {
                DeviceName = DeviceName,
                Consumer = Consumer,
                FarmId = Farmid
            };

            await _context.Devices.AddAsync(device);
            _context.SaveChanges();
            return device;
        }

        public async Task<Devices> UpdateDevice(Devices device)
        {
            _context.Entry(device).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return device;
        }

        public async Task<Devices> DeleteDevice(int id)
        {
            var device = await _context.Devices.FindAsync(id);
            if (device == null)
            {
                return null;
            }

            _context.Devices.Remove(device);
            await _context.SaveChangesAsync();
            return device;
        }
    }
}
